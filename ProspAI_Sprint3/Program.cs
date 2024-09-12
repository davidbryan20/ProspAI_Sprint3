using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using FirebaseAdmin;
using FirebaseAdmin.Auth;

var builder = WebApplication.CreateBuilder(args);

// Carregar a credencial Firebase da pasta Credentials
try
{
    GoogleCredential credential = GoogleCredential
        .FromFile(Path.Combine(AppContext.BaseDirectory, "Credentials", "prospai-f63a3-firebase-adminsdk-axxrs-6d25ab0e6b.json"));

    FirebaseApp.Create(new AppOptions()
    {
        Credential = credential
    });
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao configurar Firebase: {ex.Message}");
    throw;
}

// Adicionar Firestore como serviço 
builder.Services.AddSingleton(provider =>
{
    return FirestoreDb.Create("prospai-f63a3");
});

builder.Services.AddSingleton(provider =>
{
    var firebaseApp = FirebaseApp.DefaultInstance;
    return FirebaseAuth.GetAuth(firebaseApp);
});

builder.Services.AddControllers();

// Adicionar serviços Swagger, se necessário
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware e pipeline de execução
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
