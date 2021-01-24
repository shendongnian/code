        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var jsonContent = await reader.ReadToEndAsync();
                // Check the event type.
                // Return the validation code if it's 
                // a subscription validation request. 
                if (EventTypeSubcriptionValidation)
                {
                    var gridEvent =
                        JsonConvert.DeserializeObject<List<GridEvent<Dictionary<string, string>>>>(jsonContent)
                            .First();
                   
                    // Retrieve the validation code and echo back.
                    var validationCode = gridEvent.Data["validationCode"];
                    return new JsonResult(new{ 
                        validationResponse = validationCode
                    });
                }
                else if (EventTypeNotification)
                {
                    // Do more here...
                    return Ok();                 
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    public class GridEvent<T> where T: class
    {
        public string Id { get; set;}
        public string EventType { get; set;}
        public string Subject {get; set;}
        public DateTime EventTime { get; set; } 
        public T Data { get; set; } 
        public string Topic { get; set; }
    }
