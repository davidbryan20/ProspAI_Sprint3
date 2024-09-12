using Google.Cloud.Firestore;
namespace ProspAI_Sprint3.Persistencia.Services
{


    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService()
        {
            _firestoreDb = FirestoreDb.Create("projeto-id");
        }

        public async Task AddDocumentAsync(string collection, object data)
        {
            CollectionReference collectionRef = _firestoreDb.Collection(collection);
            await collectionRef.AddAsync(data);
        }
    }
}

