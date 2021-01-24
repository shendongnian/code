    public class EntityBase
        {
            [Key, Column(Order = 0)]
            public int Id { set; get; } = -1;
    
            private DateTime? createDate;
    
            public DateTime CreateDate
            {
                set
                {
                    createDate = value;
                }
                get
                {
                    if (createDate.HasValue)
                        return createDate.Value;
                    else
                        return DateTime.Now;
                }
            }
    
            public DateTime? UpdateDate { set; get; }
            public DateTime? DeleteDate { set; get; }
    
            public bool IsDeleted { set; get; }
    
    
            public int CreatedBy { set; get; }
    
            public int? UpdatedBy { set; get; }
    
            public int? DeletedBy { set; get; }
           
        }
