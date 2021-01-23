         public ActionResult Test()
         {
            TestClass result = Task.Run(async () => await GetNumbers()).GetAwaiter().GetResult();
            return PartialView(result);
         }
        public async Task<TestClass> GetNumbers()
        {
            TestClass obj = new TestClass();
            HttpResponseMessage response = await APICallHelper.GetData(Functions.API_Call_Url.GetCommonNumbers);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<TestClass>(result);
            }
            return obj;
        }
