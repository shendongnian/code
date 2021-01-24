        [HttpGet]
        public async Task<string> GetById(int id)
        {
            try
            {
                User user = await userManager.GetByIdAsync(id);
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                return JsonConvert.SerializeObject(user, jsonSerializerSettings); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
