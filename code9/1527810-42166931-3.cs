        public class VM : IDataErrorInfo
        {
            public string this[string columnName]
            {
                get
                {
                    if (columnName.Equals( "Selected"))
                    {
                        if (!DList.Select(m => m.Number).Contains(Selected))
                            return "Selected number must be in the combo list";
                    }
                    return null;
                }
            }
