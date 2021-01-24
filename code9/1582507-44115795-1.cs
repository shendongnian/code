        public static void Main(string[] args)
        {
            //read a config from file
            byte[] fileBytes = File.ReadAllBytes(@"C:\Users\ABC\Desktop\config.json");
            StringReader stringReader = new StringReader(Encoding.UTF8.GetString(fileBytes));
            JsonSerializer serializer = new JsonSerializer();
            MyFancyPermissionConfig val = (MyFancyPermissionConfig)serializer.Deserialize(stringReader, typeof(MyFancyPermissionConfig));
            //write encrypted config to file
            _SerializeConfig(@"C:\Users\ABC\Desktop\config_enc.json", val);
            //deserialize it again. 
            var des = _DeSerializeConfig(@"C:\Users\ABC\Desktop\config_enc.json");
            Console.ReadLine();
        }
