    public class Context
        {
            //Property Injection to be used for all repo classes
            private StatisticsEntities _statContext = new StatisticsEntities();
            public StatisticsEntities StatContext { get; set; }
        }
