    using System;
    namespace program
    {
        class program
        {
            static void Main(string[] args)
            {
                DataCls dataCls = new DataCls();
                    
                string message = "[AE][1W] Message:sample message Priority:Info Time:Sep 21 2016  1:13PM Tag:/abc/pqr/xyz";
                message = message.Replace("Message:","::").Replace("Priority:","::").Replace("Time:","::").Replace("Tag:","::");
                var parts = message.Split("::");
                dataCls.Message = parts[0];
                dataCls.Priority = parts[1];
                dataCls.Time  = Convert.ToDateTime(parts[2]);
                dataCls.Tag = parts[3];
            }
        }
    
        public class DataCls
        {
            public string Message { get; set; }
            public string Priority { get; set; }
            public DateTime Time { get; set; }
            public string Tag { get; set; }
        }
    }
