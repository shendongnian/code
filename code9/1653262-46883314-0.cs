    public class Test: ICloneable
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public object Clone()
            {
                return new Sample { Id = this.Id, Name = this.Name };
            }
        }
