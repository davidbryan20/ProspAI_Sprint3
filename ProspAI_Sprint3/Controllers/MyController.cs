using FirebaseAdmin.Auth;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Mvc;

namespace ProspAI_Sprint3.Controllers
{
    public class MyController : Controller
    {
        private readonly FirestoreDb _firestoreDb;
        private readonly FirebaseAuth _firebaseAuth;

        public MyController(FirestoreDb firestoreDb, FirebaseAuth firebaseAuth)
        {
            _firestoreDb = firestoreDb;
            _firebaseAuth = firebaseAuth;
        }

        
        [HttpGet("add-data")]
        public async Task<IActionResult> AddData()
        {
            var docRef = _firestoreDb.Collection("users").Document("alovelace");
            var data = new Dictionary<string, object>
        {
            { "first", "Ada" },
            { "last", "Lovelace" },
            { "born", 1815 }
        };
            await docRef.SetAsync(data);
            return Ok("Data added to Firestore");
        }

        
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] string token)
        {
            try
            {
                var decodedToken = await _firebaseAuth.VerifyIdTokenAsync(token);
                string uid = decodedToken.Uid;
                return Ok(new { uid });
            }
            catch (FirebaseAuthException)
            {
                return Unauthorized();
            }
        }
    }
}