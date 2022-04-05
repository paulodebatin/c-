// Para maiores informações, acesse: 
// https://kb.objectrocket.com/mongo-db/create-a-c-and-mongodb-project-using-net-1168
// http://zetcode.com/csharp/mongodb/

using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connString = "mongodb://admin:123456@localhost:27017";
                MongoClient client = new MongoClient(connString);

                IMongoDatabase db = client.GetDatabase("vendas");

                var pessoas = db.GetCollection<BsonDocument>("pessoas");
                var documents = pessoas.Find(new BsonDocument()).ToList();

                foreach (BsonDocument doc in documents)
                {
                    Console.WriteLine(doc.ToString());
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}