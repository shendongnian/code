    public class ListWorkSheet : List<WorkSheet>
    {
        public override void Add(WorkSheet source)
        {
            if(source != null)
                Add(source);
        }
    }
