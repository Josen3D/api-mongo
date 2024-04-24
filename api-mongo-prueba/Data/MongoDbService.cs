using MongoDB.Driver;

namespace api_mongo_prueba.Data
{
    // create configuration to connect to MongoDB
    public class MongoDbService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase? _database;

        public MongoDbService(IConfiguration configuration)
        {
            _configuration = configuration;

            // get the connection string from appsettings
            var connectionString = _configuration.GetConnectionString("dbConnection");
            var mongoUrl = MongoUrl.Create(connectionString); // create mongoDB url
            var mongoClient = new MongoClient(mongoUrl); // create mongoDB client
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName); // get the database from mongo url
        }
        public IMongoDatabase? Database => _database;
    }
}
