      public class TableVisibilitySettings
        {
            public int Id { get; set; }
            public int GroupId { get; set; }
            public virtual Group Group { get; set; }
            public bool ContructionYear { get; set; }
            public bool Power { get; set; }
            public bool IsConvertible { get; set; }
        }
