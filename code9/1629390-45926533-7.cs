    public class ListWorkSheets : List<WorkSheets>
    {
        public new void Add(WorkSheets source)
        {
            if(source != null)
                base.Add(source);
        }
    }
