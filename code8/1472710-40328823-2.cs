    public class SomeEntityType : ILoadFromDataRow
    {
        public SomeEntityType()
        {
        }
        public bool LoadFromDataRow(System.Data.DataRow DR, IEnumerable<string> SelectedTableColumnList)
        {
            bool Success;
            int FieldCount;
            Success = true;
            FieldCount = 0;
            try
            {
                foreach (string DBColumn in SelectedTableColumnList)
                {
                    FieldCount += 1;
                    switch (DBColumn)
                    {
                        case @"Some Field":
                            SomeField = DR[@"FunkyDBFieldName"].ToString();
                            break;
                        case @"Another Field":
                            AnotherField = DR[@"Even More Funky"].ToString();
                            break;
                        case @"Yet Another Field":
                            YetAnotherField = DR[@"Very bad fielD NaMe With SpaCes"].ToString();
                            break;
                    }
                }
                //Conditional Logic depending on your scenario
                if (string.IsNullOrEmpty(SomeField))
                {
                    if (FieldCount == 1)
                    {
                        // Some Logic to calculate stuff
                    }
                }
            }
            catch
            {
                Success = false;
            }
            return Success;
        }
        public string SomeField { get; set; }
        public string AnotherField { get; set; }
        public string YetAnotherField { get; set; }
    }
