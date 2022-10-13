using Google.Cloud.Firestore;

namespace macro
{
    [FirestoreData]
    class FirebaseProperty
    {
        [FirestoreProperty]
        public bool userLicense { get; set; }
        [FirestoreProperty]
        public bool userState { get; set; }
        [FirestoreProperty]
        public string userMacAdress { get; set; }
        [FirestoreProperty]
        public string userArsCode { get; set; }
    }
}
