    public class ListWorkSheet : List<WorkSheet>
    {
        public new void Add(WorkSheet source)
        {
            if(source != null)
                base.Add(source);
        }
    }
