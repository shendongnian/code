        [TestMethod]
        public void TestMethod1()
        {
            URequest<Customer> request = new URequest<Customer>();
            request.password = "test";
            request.userName = "user";
            request.requestList = new List<Customer>();
            request.requestList.Add(new Customer() { Name = "customer" });
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.Converters.Add(new URequestConverter<Customer>());
            Console.WriteLine(JsonConvert.SerializeObject(request, settings));
        }
