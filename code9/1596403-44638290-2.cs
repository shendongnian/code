    static void Main(string[] args)
            {
                var teamObj = new Team();
                var json = new JavaScriptSerializer().Serialize(teamObj.GetSerializeInfo());
                Console.WriteLine(json);
                Console.ReadLine();
            }
