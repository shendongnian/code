        public  class WorkRecord
        {
            public readonly String name;
            public readonly DateTime StarTime;
            public readonly DateTime EndTime;
            public WorkRecord(string name, DateTime starTime, DateTime endTime)
            {
                this.name = name;
                StarTime = starTime;
                EndTime = endTime;
            }
            public WorkRecord(string name, string starTime, string endTime)
            {
                this.name = name;
                StarTime = DateTime.ParseExact(starTime, "HH:mm", null);
                EndTime = DateTime.ParseExact(endTime, "HH:mm", null);
            }
        }
