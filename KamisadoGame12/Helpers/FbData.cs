using Android.App;
using Android.Gms.Extensions;

using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Nio.FileNio;
using System.Threading.Tasks;
//using firebase.firestore;

namespace KamisadoGame12.Helpers
{
    internal class FbData
    {
        public readonly FirebaseAuth auth;
        public readonly FirebaseApp app;
        public FirebaseFirestore firestore;

        public FbData()
        {
            app = FirebaseApp.InitializeApp(Application.Context);
            if(app is null)
            {
                FirebaseOptions options = GetMyOptions();
                app = FirebaseApp.InitializeApp(Application.Context, options);
            }
            firestore = FirebaseFirestore.GetInstance(app);
            auth = FirebaseAuth.Instance;
        }
        private FirebaseOptions GetMyOptions()
        {
            return new FirebaseOptions.Builder().SetProjectId("kamisadogame-28a02")
                .SetApplicationId("kamisadogame-28a02")
                .SetApiKey("AIzaSyDd2MprVXjnC0eHvN5NiuHhhWmOOe1zrDY")
                .SetStorageBucket("kamisadogame-28a02.firebasestorage.app").Build();
                
        }
        public async Task CreateUser(string email, string password) 
        {
            await auth.CreateUserWithEmailAndPassword(email, password);
        }
        public async Task SingIn(string email, string password)
        {
            await auth.SignInWithEmailAndPassword(email, password);
        }
        public Android.Gms.Tasks.Task GetCollection(string CollectionName)
        {
            return firestore.Collection(CollectionName).Get();
        }
        public void AddCollectionSnapShotListener(Activity activity, string cName)
        {
            firestore.Collection(cName).AddSnapshotListener((IEventListener)activity);
        }

        public Android.Gms.Tasks.Task GetCollection(string cName, string id)
        {
            return firestore.Collection(cName).Document(id).Get();
        }
        public Android.Gms.Tasks.Task DeleteFsDocument(string cName, string id)//asyncron
        {
            return firestore.Collection(cName).Document(id).Delete();
        }

        //public string GetNewDocumentId(string cName)
        //{
        //DocumentReference dr = firestore.Collection(cName).Document();
        //return dr.Id;
        // }

    }
}