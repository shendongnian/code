    public class DateInfoExt : IBqlTable
    {
        ...
        public abstract class description : IBqlField { }
        [PXString()]
        [PXUIField(DisplayName = "Description", Visible = false)]
        public virtual string Description { get; set; }
        ...
            
    }
