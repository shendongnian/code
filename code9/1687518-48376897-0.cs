    [Serializable]
    public class FFDialog1
    {
        public string Test { get; set; }
        public string Description { get; set; }
        public static IForm<FFDialog1> BuildForm()
        {
            return new FormBuilder<FFDialog1>()
                .Message("Welcome to the first FormFlow dialog")
                .Field(nameof(Test))
                .Field(nameof(Description))
                .Build();
        }
    }
    public enum YesOrNo
    {
        Yes,
        No
    }
    
    [Serializable]
    public class FFDialog2
    {
        public YesOrNo? Confirmation;
        public string Input { get; set; }
        public static IForm<FFDialog2> BuildForm()
        {
            return new FormBuilder<FFDialog2>()
                .Message("Welcome to the second FormFlow dialog")
                .Field(nameof(Confirmation))
                .Field(nameof(Input))
                .Build();
        }
    }
