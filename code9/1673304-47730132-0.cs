       public T Get<T>(string key)
        {
            if (typeof(T) == typeof(GenericIsAuthenticatedResponse) && key == "1234")
                return JsonConvert.DeserializeObject<T>(GetGenericIsAuthenticatedResponse());
            return default(T);
        }
        private static string GetGenericIsAuthenticatedResponse()
        {
            var r = new GenericIsAuthenticatedResponse
            {
                Username = "email.email.com",
                AuthCode = "1234"
            };
            return JsonConvert.SerializeObject(r);
        }
