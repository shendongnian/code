    public class LogString{
        public string val {get; set;}
        public string data {get; set;}
    }
The rest was the same:
        [HttpPost]
        public void Post([FromBody] LogString message)
        {      
            Console.WriteLine(message.val);
        }
After adding that it started working.
