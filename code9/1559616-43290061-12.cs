    static void Main(string[] args)
     {   
      //Create an instance of the person class
      Person person1 = new Person();
      Person person2 = new Person();
      Person person3 = new Person();
      //Create a json object from your file 
       JObject json = JObject.Parse(File.ReadAllText(@"json-file-path"));
      //Get the jarray for each person 
      JArray a1 = (JArray)json["person1"];
      JArray a2 = (JArray)json["person2"];
      JArray a3 = (JArray)json["person3"];
      //person 1
      person1.Name = a1[0]["name"].ToString();
      person1.Age =  Convert.ToInt16(a1[1]["age"]);
      person1.Height = Convert.ToInt16(a1[2]["height"]);
      person1.Hobby = a1[3]["hobby"].ToString();
      //person 2
      person2.Name = a2[0]["name"].ToString();
      person2.Age = Convert.ToInt16(a2[1]["age"]);
      person2.Height = Convert.ToInt16(a2[2]["height"]);
      person2.Hobby = a2[3]["hobby"].ToString();
       //person 3
       person3.Name = a3[0]["name"].ToString();
       person3.Age = Convert.ToInt16(a3[1]["age"]);
       person3.Height = Convert.ToInt16(a3[2]["height"]);
       person3.Hobby = a3[3]["hobby"].ToString();
        Console.WriteLine(person1.ToString());
        Console.WriteLine(person2.ToString());
        Console.WriteLine(person3.ToString());
    }
