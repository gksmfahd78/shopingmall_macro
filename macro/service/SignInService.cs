
namespace macro
{
    class SignInService
    {
        private string userId;
        private string userPw;
        private string userSkPayPw;
        private string userApiKey;
        private string userProductLink;
        private int userTimeSleep;
        private bool userOptionSave;
        private bool userInfoSave;
        private bool userLogSave;

        //id properti
        public string id
        {
            get { return userId; }
            set { userId = value; }
        }

        //pw properti
        public string pw
        {
            get { return userPw; }
            set { userPw = value; }
        }

        //skpay pw properti
        public string skpayPw
        {
            get { return userSkPayPw; }
            set { userSkPayPw = value; }
        }

        //product link properti
        public string productLink
        {
            get { return userProductLink; }
            set { userProductLink = value; }
        }

        //api key properti
        public string apiKey
        {
            get { return userApiKey; }
            set { userApiKey = value; }
        }


        public int sleepTime
        {
            get { return userTimeSleep; }
            set { userTimeSleep = value; }
        }

        public bool optionSave
        {
            get { return userOptionSave; }
            set { userOptionSave = value; }
        }

        public bool infoSave
        {
            get { return userInfoSave; }
            set { userInfoSave = value; }
        }

        public bool logSave
        {
            get { return userLogSave; }
            set { userLogSave = value; }
        }

    }
}
