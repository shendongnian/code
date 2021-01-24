    public static class FirstValueField
    {
        public static Field FieldProperties{get; set;} //<-- See this needs to be property
    
        static FirstValueField()
        {
            FieldProperties = new Field();
        }
    }
