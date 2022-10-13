using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

using Google.Cloud.Firestore;

namespace macro
{
    public partial class SignIn : Form
    {
        bool flage = true;
        public string signInId;
        FireBaseService fireBaseService = new FireBaseService();

        public SignIn()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, System.Windows.Forms.Keys keyData)
        {
            System.Windows.Forms.Keys key = keyData & ~(System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Control);

            switch (key)
            {
                case System.Windows.Forms.Keys.Enter:
                    signInBtn();
                    break;
                case System.Windows.Forms.Keys.S:
                    if ((keyData & System.Windows.Forms.Keys.Control) != 0)
                    {
                        if (signin_auto_sign_save_check_box.Checked)
                            signin_auto_sign_save_check_box.Checked = false;
                        else
                            signin_auto_sign_save_check_box.Checked = true;
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            fireBaseService.setting();
            fireBaseService.fsd = FirestoreDb.Create("macro-50943");

            signin_auto_sign_save_check_box.Checked = honestcoder.Properties.Settings.Default.signin_InfoSaveCheck;
            signin_id_text_box.Text = honestcoder.Properties.Settings.Default.signin_idBox;
            signin_pw_text_box.Text = honestcoder.Properties.Settings.Default.signin_pwBox;
        }

        private void signin_signup_button_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void signInBtn()
        {
            if (flage)
            {
                flage = false;
                if (signin_id_text_box.Text == "")
                {
                    MessageBox.Show("아이디를 입력해주세요.");
                    signin_id_text_box.Focus();

                }

                else if (signin_pw_text_box.Text == "")
                {
                    MessageBox.Show("아이디를 입력해주세요.");
                    signin_pw_text_box.Focus();
                }

                else
                {

                    if (signin_auto_sign_save_check_box.Checked)
                    {
                        honestcoder.Properties.Settings.Default.signin_idBox = signin_id_text_box.Text;
                        honestcoder.Properties.Settings.Default.signin_pwBox = signin_pw_text_box.Text;
                        honestcoder.Properties.Settings.Default.signin_InfoSaveCheck = signin_auto_sign_save_check_box.Checked;
                        honestcoder.Properties.Settings.Default.Save();
                    }

                    else
                    {
                        honestcoder.Properties.Settings.Default.signin_idBox = "";
                        honestcoder.Properties.Settings.Default.pwBox = "";
                        honestcoder.Properties.Settings.Default.signin_InfoSaveCheck = false;
                        honestcoder.Properties.Settings.Default.Save();
                    }

                    signInManagement(signin_id_text_box.Text, signin_pw_text_box.Text);
                }
                flage = true;
            }
        }

        public async void signInManagement(string id, string pw)
        {
            DES des = new DES("up220113");

            HdIDListService hdIDListService = new HdIDListService();
            List<string> list = hdIDListService.getCPUIDList();
            string lenMacAdress = hdIDListService.getLenMACAddress();
            string encrypt = des.result(DES.DesType.Encrypt, pw);

            bool idCheck = await fireBaseService.findInfo(id, encrypt);
            bool liCheck = await fireBaseService.licenseCheck(id);
            bool lenMacAdressCheck = await fireBaseService.lenMacAdressCheck(id, lenMacAdress);
            bool stateCheck = await fireBaseService.stateCheck(id);

            if (idCheck)
            {
                if(liCheck && !lenMacAdressCheck)
                {
                    if(!stateCheck)
                    {
                        try
                        {
                            this.Hide();
                            //await fireBaseService.stateChange(true, id);
                            MessageBox.Show("로그인에 성공하였습니다.");
                            SignIn11Market signIn11Market = new SignIn11Market(id);
                            signIn11Market.Show();
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("error : " + ex);
                            return;
                        }
                    }

                    else
                    {
                        MessageBox.Show("현재 계정이 사용중입니다.");
                        signin_id_text_box.Text = "";
                        signin_pw_text_box.Text = "";
                        signin_id_text_box.Focus();
                        flage = true;
                    }
                }

                else if(!liCheck && !lenMacAdressCheck)
                {
                    try
                    {
                        MessageBox.Show("현재 계정의 라이센스가 만료되었습니다.");
                        signin_id_text_box.Text = "";
                        signin_pw_text_box.Text = "";
                        signin_id_text_box.Focus();
                        flage = true;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("error : " + ex);
                        return;
                    }
                }

                else
                {
                    try
                    {
                        MessageBox.Show("현재 계정에 등록되어 있는 pc가 아닙니다.");
                        signin_id_text_box.Text = "";
                        signin_pw_text_box.Text = "";
                        signin_id_text_box.Focus();
                        flage = true;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("error : " + ex);
                        return;
                    }
                }
            }

            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 틀렸습니다.");
                signin_id_text_box.Text = "";
                signin_pw_text_box.Text = "";
                signin_id_text_box.Focus();
                flage = true;
            }
        }

        private void signin_signin_button_Click(object sender, EventArgs e)
        {
            signInBtn();
        }

        private void info_button_Click(object sender, EventArgs e)
        {

        }

        private void support_button_Click(object sender, EventArgs e)
        {
            Process.Start("https://toss.me/honest");
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
