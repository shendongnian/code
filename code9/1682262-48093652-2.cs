    public class TranslationModel
    {
        public int Code
        {
            get
            {
                //Parse string
                if (!int.TryParse(CodeStr, out var val))
                {
                    val = -1;
                }
                return val;
            }
        }
        public string CodeStr { get; set; }
        public string FieldName { get; set; }
        public string Description { get; set; }
    }
