        [HttpPost]
        public IActionResult MyAction([FromBody] dynamic request)
        {            
            if (request != null)
            {
                try
                {
                    var objAttempt =
                        JsonConvert.DeserializeObject<MyModel>(
                            JsonConvert.SerializeObject(request));
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
