using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DatabaseConnectionProvider
{
    public class NoteContext
    {
        private readonly IMongoDatabase _database = null;
        private const string pucka = "mongodb://swierzakiteam:lubieplacki1A@localhost/swiezakidb";

        public NoteContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(pucka);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Note> Notes
        {
            get { return _database.GetCollection<Note>("Note"); }
        }
    }
}