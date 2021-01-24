        public static string GenerateToken(Token claims)
        {
            string serialised = Newtonsoft.Json.JsonConvert.SerializeObject(claims);
            return serialised;
        }
