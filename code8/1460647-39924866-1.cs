    class Person
    {
        public int Ch_ID { get; set; }
        public int User_id{ get; set; }
        public string Ch_Name { get; set; }
        // all properties...
        public override string ToString()
        {
            return string.Format("User ID: {0} \n Name: {1}", User_id, Ch_Name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Parsing into a class from JSON file using JavaScriptSerializer class
            string path = "C:\\path\\";
            // Deserialize JSON from file.
            String JSONfile = File.ReadAllText(path + "JSON.json");
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Person p1 = ser.Deserialize<Person>(JSONfile);
            Console.WriteLine(p1);
    
            List<Person> newList = new List<Person>();
            // add instance of the class to the list
            newList.Add(p1);
            // do work whith your list...
        }
    }
