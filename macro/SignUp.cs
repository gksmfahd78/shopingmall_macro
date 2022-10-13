#define TEST220113

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

using Google.Cloud.Firestore;

namespace macro
{
    public partial class SignUp : Form
    {
        FireBaseService fireBaseService = new FireBaseService();
        bool flage = true;

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            fireBaseService.setting();
            fireBaseService.fsd = FirestoreDb.Create("macro-50943");
        }

        private void signupBtn()
        {
            flage = true;
            if(flage)
            {
                flage = false;
                if (signup_id_text_box.Text == "")
                {
                    MessageBox.Show("아이디를 입력해주세요.", "알림",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_id_text_box.Focus();
                }

                else if (signup_pw_text_box.Text == "")
                {
                    MessageBox.Show("비밀번호를 입력해주세요.", "알림",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_pw_text_box.Focus();
                }

                else if (signup_pw2_text_box.Text == "")
                {
                    MessageBox.Show("비밀번호를 확인을 입력해주세요.", "알림",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_pw2_text_box.Focus();
                }

                else if (signup_name_text_box.Text == "")
                {
                    MessageBox.Show("이름을 입력해주세요.", "알림",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_name_text_box.Focus();
                }

                else if (!signup_info_check_box.Checked)
                {
                    MessageBox.Show("개인정보 활용 동의해주세요.", "알림",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_info_check_box.Focus();
                }

                else if (!signup_stop_check_box.Checked)
                {
                    MessageBox.Show("되팔램/채굴 금지 동의해주세요.", "알림",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    signup_info_check_box.Focus();
                }

                else
                {
                    if (signup_pw_text_box.Text == signup_pw2_text_box.Text)
                    {
                        try
                        {
                            HdIDListService hdIDListService = new HdIDListService();
                            List<string> list = hdIDListService.getCPUIDList();
                            string cpuId = hdIDListService.getCPUIDList2str(list);
                            string gpuName = hdIDListService.getGpuName();
                            string lenMacAdress = hdIDListService.getLenMACAddress();
                            string hostIP = hdIDListService.getHostIP();

                            DES des = new DES("up220113");
                            string encrypt = des.result(DES.DesType.Encrypt, signup_pw_text_box.Text);
                            signUpManagement(
                                            signup_id_text_box.Text,
                                            encrypt,
                                            signup_name_text_box.Text,
                                            cpuId,
                                            gpuName,
                                            hostIP,
                                            lenMacAdress,
                                            signup_info_check_box.Checked,
                                            signup_stop_check_box.Checked
                                            );
                            flage = true;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("error : " + ex);
                        }
                    }

                    else
                    {
                        MessageBox.Show("비밀번호가 서로 일치하지 않습니다.", "알림",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        signup_pw_text_box.Focus();
                        flage = true;
                    }
                }
                flage = true;
            }
        }
          

        private bool phoneNumberCheck(string phone)
        {

            if (phone.Length == 10 || phone.Length == 11)
            {
                Regex regex = new Regex(@"01{1}[016789]{1}[0-9]{7,8}");
                Match match = regex.Match(phone);
                if (match.Success)
                    return true;
                else
                    return false;
            }

            else
            {
                return false;
            }
              
        }

        public async void signUpManagement(string id, string pw, string name, string cpuId, string gpuName, string hostIP, string lenMacAdress, bool info, bool stop)
        {
            bool userIdCheck = await fireBaseService.findUserId(id);
            bool lenMacAdressCheck = await fireBaseService.findUserLenMacAdress(lenMacAdress);

            if (!userIdCheck)
            {
                if(!lenMacAdressCheck)
                {
                    fireBaseService.join(id, pw, name, cpuId, gpuName, hostIP, lenMacAdress, info, stop);
                    MessageBox.Show("회원가입이 완료되었습니다.");
                    this.Close();
                }

                else
                {
                    MessageBox.Show("등록되었던 사용자입니다.");
                    this.Close();
                }
            }

            else 
            {
                MessageBox.Show("아이디가 중복되었습니다.");
                this.Close();
            }
        }

        private void signup_cancle_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void signup_sigunup_button_Click(object sender, EventArgs e)
        {
            signupBtn();
        }

        private void signup_adress_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void link_button_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/1e0UWj3ifssLdDJxBZwOiSVV24ovSmFJ0ChJAlRfbddo/edit?usp=sharing");
        }

        private void se_button_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/1pn4pfGKGEAmYcsvNG0HS74hQg_tgndCf1sHlQcYC2ZI/edit?usp=sharing");
        }
    }
}
