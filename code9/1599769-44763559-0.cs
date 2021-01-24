            public class Line
            {
                public int LineId { get; set; }
                public virtual Provider Provider { get; set; }
                public string Login { get; set; }
                public string Pass { get; set; }
                public string Domain { get; set; }
                public string ProjectOwner { get; set; }
                public string Project { get; set; }
                public string OutNumber { get; set; }
                public string InNumber { get; set; }
                public string Description { get; set; }
                public DateTime Begin_datetime { get; set; }
                public DateTime End_datetime { get; set; }
                public Human TechGuy { get; set; }
                public Human Manager { get; set; }
                public virtual ICollection<LineStatusHistory> ChangeHistory { get; } = new HashSet<LineStatusHistory>();
            }
    
            public class LineStatusHistory
            {
                [Key( )]
                public int LineId { get; set; }
                [Key()]
                public int LineStatusHistoryId { get; set; }
                public virtual Line Line { get; set; }
                public DateTime ChangeDate { get; set; }
                public string Change { get; set; }
            }
    
    
            public class Provider
            {
                public int ProviderId { get; set; }
                public string Name { get; set; }
                public string OurSideData { get; set; }
                public string TheirSideData { get; set; }
                public string Description { get; set; }
                public DateTime Begin_datetime { get; set; }
                public DateTime End_datetime { get; set; }
                public Currency Currency { get; set; }
                public virtual ICollection<Line> Lines { get; } = new HashSet<Line>();
            }
