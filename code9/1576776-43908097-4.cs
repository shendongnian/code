        [Route("api/TaskApi")]
        [HttpPost]
        public String TaskApi(tempTask tempTask)
        {
            return "Some Message";
        }
        public class tempTask
        {
            public int id { get; set; }
            public int projectId { get; set; }
            public string task_name { get; set; }
            public string description { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public bool sms { get; set; }
            public bool email { get; set; }
            public int status { get; set; }
            public List<int> tempUsers { get; set; }
        }
