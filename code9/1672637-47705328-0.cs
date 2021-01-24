    public class MyList: Collection<string>
    {
    
        protected override void InsertItem(int index, string newItem)
        {
            DoValidation();
        }
    
    }
