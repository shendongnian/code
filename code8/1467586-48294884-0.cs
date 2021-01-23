    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Mongo_console
    {
        class Program
        {
            public static void Main(string[] args)
            {
                MongoClient client = new MongoClient();
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase("admin");
                MongoCollection<Book> collection = db.GetCollection<Book>("Book");
    
    
                Book book1 = new Book
                {
                    Id = ObjectId.GenerateNewId(),
                    name = "Reel To Real"
                };
                Book book2 = new Book
                {
                    Id = ObjectId.GenerateNewId(),
                    name = "Life"
                };
                collection.Save(book1);
                collection.Save(book2);
    
                var query = Query<Book>.EQ(u => u.Id, new ObjectId("5a5ee6360222da8ad498f3ff"));
                Book list = collection.FindOne(query);
                Console.WriteLine( "Book Name  " + list.name);
             
               
                Console.ReadLine();
            }
        }
        public class Book
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string name { get; set; }
    
            public Book()
            {
            }
    
            public Book(ObjectId id, string name)
            {
                this.Id = id;
                this.name = name;
            }
        }
    }
