        class Program
    {
        static void Main(string[] args)
        {
            string jsonstring = @"{ ""Message"":""The request is invalid."",""ModelState"":{ ""user_FirstName"":[""The FirstName field is required.""] }}";
            var serializer = new JavaScriptSerializer();
            var jsonObject = serializer.Deserialize<Example>(jsonstring);
            Console.WriteLine("Error Message : " + jsonObject.Message);
            Console.WriteLine("Error Message : " + jsonObject.ModelState.user_FirstName);
            Console.Read();
        }
    }
