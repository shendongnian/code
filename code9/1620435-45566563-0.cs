    public class CustomItemTemplate : ITemplate
    {
        // stuff omitted for brevity     
    
        // Override InstantiateIn() method
        void ITemplate.InstantiateIn(Control container)
        {
            // set the ID of the container these fields are in!
            container.ID = _columnName;
            // rest of your code
            // make sure hidden_time is still unique!
            var hiddenInput = new HiddenField
                {
                    ID = $"{_columnName.Replace(":", "_")}_hidden_time",
                    Value = _columnName
                };
        }
    }
