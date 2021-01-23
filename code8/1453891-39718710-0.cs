    class Program
        {
            static void Main(string[] args)
            {
                MainAsync(args).GetAwaiter().GetResult();
                Console.WriteLine("");
                Console.WriteLine("press enter");
                Console.ReadKey();
            }
    
            static async Task MainAsync(string[] args)
            {
                ModelKnjiga knga = new ModelKnjiga()
                {
                    autor = "Author",
                    godina_izdanja = "2015",
                    izdavac = "izdavac",
                    naziv = "naziv",
                    ocjena = "20",
                    završio = true,
                    čitam = true
                };
    
                ModelKnjiga knga2 = new ModelKnjiga()
                {
                    autor = "Author2",
                    godina_izdanja = "2016",
                    izdavac = "izdavac2",
                    naziv = "naziv2",
                    ocjena = "202",
                    završio = false,
                    čitam = false
                };
    
                ModelKnjiga knga3 = new ModelKnjiga()
                {
                    autor = "Author3",
                    godina_izdanja = "2017",
                    izdavac = "izdavac3",
                    naziv = "naziv3",
                    ocjena = "203",
                    završio = false,
                    čitam = true
                };
    
                ModelKorisici mcor = new ModelKorisici()
                {
                    email = "no@where.com",
                    ime = "ime",
                    KnjigaLista = new List<ModelKnjiga>() { knga, knga2 },
                    kor_ime = "kor_ime",
                    uloga = "uloga",
                    lozinka = "lozinka",
                    prezime = "prezime"
                };
    
                var client = new MongoClient();
                var db = client.GetDatabase("KnjigaDB");
                var korisici = db.GetCollection<ModelKorisici>("Korisici");
    
                //After first run comment this line out
                await korisici.InsertOneAsync(mcor);
    
    
                //After first run UNcomment these lines
                //var filter = Builders<ModelKorisici>.Filter.Eq("email", "no@where.com");
                //var update = Builders<ModelKorisici>.Update.Push("KnjigaLista", knga3);
                //await korisici.UpdateOneAsync(filter, update);
            }
    
        }
