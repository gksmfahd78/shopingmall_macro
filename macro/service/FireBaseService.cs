#define TEST220113

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace macro
{
    class FireBaseService
    {
        public FirestoreDb fireStoreDb;
        private string collectionName = "Join220124";

        public void setting()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"macro-50943-firebase-adminsdk-mm3m2-5ad6825e70.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
        }

        public FirestoreDb fsd
        {
            set { fireStoreDb = value; }
            get { return fireStoreDb; }
        }

        public void join(string id, string pw, string name, string cpuId, string gpuName, string hostIP, string lenMacAdress, bool info, bool stop)
        {
            DocumentReference DOC = fsd.Collection(collectionName).Document(id);
            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"userID", id },
                {"userPW", pw },
                {"userName", name },
                {"userCpuID", cpuId },
                {"userGpuName", gpuName },
                {"userMacAdress", lenMacAdress },
                {"userHostIP", hostIP },
                {"userInfo", info },
                {"userUseStop", stop },
                {"userLicense", false },
                {"userSignin", false },
                {"userBuyState", false },
                {"userArsCode", "" },
                {"userSignUp", DateTime.Now.ToString("yyyy-MM-dd") },
            };
            DOC.SetAsync(data);
        }


        public async Task<bool> findInfo(string userId, string userPw)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId).WhereEqualTo("userPW", userPw);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }
       
        public async Task<bool> findUserCpuId(string cpuId)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userCpuID", cpuId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> findUserLenMacAdress(string lenMacAdress)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userMacAdress", lenMacAdress);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> findUserId(string userId)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                if (docsnap.Exists)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> licenseCheck(string userId)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                FirebaseProperty fp = docsnap.ConvertTo<FirebaseProperty>();

                if (docsnap.Exists)
                {
                   if(!fp.userLicense)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> lenMacAdressCheck(string userId, string lenMacAdress)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                FirebaseProperty fp = docsnap.ConvertTo<FirebaseProperty>();

                if (docsnap.Exists)
                {
                    if (fp.userMacAdress == lenMacAdress)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> stateChange(bool state, string userId)
        {

            DocumentReference docref = fsd.Collection(collectionName).Document(userId);

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"userSignin", state },
            };

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(data);
                return true;
            }

            return false;
        }

        public async Task<bool> stateCheck(string userId)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                FirebaseProperty fp = docsnap.ConvertTo<FirebaseProperty>();

                if (docsnap.Exists)
                {
                    if (!fp.userState)
                        return false;
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> arsCodeChange(string arsCode, string userId)
        {
            DocumentReference docref = fsd.Collection(collectionName).Document(userId);

            Dictionary<string, object> data = new Dictionary<string, object>()
            {
                {"userArsCode", arsCode },
            };

            DocumentSnapshot snap = await docref.GetSnapshotAsync();
            if (snap.Exists)
            {
                await docref.UpdateAsync(data);
                return true;
            }
            return false;
        }

        public async Task<bool> arsCodeCheck(string userId)
        {
            Query qref = fsd.Collection(collectionName).WhereEqualTo("userID", userId);
            QuerySnapshot snap = await qref.GetSnapshotAsync();

            foreach (DocumentSnapshot docsnap in snap)
            {
                FirebaseProperty fp = docsnap.ConvertTo<FirebaseProperty>();

                if (docsnap.Exists)
                {
                    if (fp.userArsCode == "")
                        return false;
                    return true;
                }
            }
            return false;
        }
    }
}
