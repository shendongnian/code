        static void Main(string[] args)
        {
             var path = "path to xml" or stream which contains your xml.
            XmlSerializer xs = new XmlSerializer(typeof(Report));
            using (StreamReader rd = new StreamReader(path))
            {
                var result = (Report)xs.Deserialize(rd);
                foreach(var p in result.Person)
                        { //TODO
                       }
            }
           
                Console.ReadLine();
        }
    }
