        public static string GenerateToken(Guid id, params object[] data)
        {
            var claims = new List<object>(data);
            claims.Add(new
            {
                id = id
            });
            string serialised = Newtonsoft.Json.JsonConvert.SerializeObject(claims);
            return serialised;
        }
