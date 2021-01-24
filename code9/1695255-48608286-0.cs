        class Program
    {
       
        static void Main(string[] args)
        {
            List<SaveFavo> ls = new List<SaveFavo>();
            bool bExists = File.Exists("Favo.Xml");
            XmlSerializer xs = new XmlSerializer(typeof(List<SaveFavo>));
            if (!bExists)
            {
                //creates file if file doesn't exist
                using (FileStream fs = File.Create("Favo.Xml"))
                {
                    AddFavo(ls, "Test1");
                    xs.Serialize(fs, ls);
                    //Closes the file
                    fs.Close();
                }
            }
            else
            {
                
                var fs = File.Open("Favo.Xml", FileMode.OpenOrCreate);
                //reads existing file and deserialize into list<SaveFavo>
                ls = xs.Deserialize(fs) as List<SaveFavo>;
                fs.Close();
            }
            //test sample 
            for (int i = 2; i < 10; i++)
                using (FileStream fs = File.OpenWrite("Favo.Xml"))
                //add new content and saves file
                {
                    AddFavo(ls, $"Test{i}");
                    xs.Serialize(fs, ls);
                    fs.Close();
                }
        }
        private static void AddFavo(List<SaveFavo> ls, string favo)
        {
            SaveFavo sf = new SaveFavo();
            //Fills public string Name with tbname.text
            sf.Name = favo;
            //Adds name to the list
            ls.Add(sf);
        }
    }
    public class SaveFavo
    {
        public string Name { get; set; }
        public SaveFavo() { }
    }
