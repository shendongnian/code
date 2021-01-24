    public enum ContentClassification
    {
        Confidential_Restricted = 1,
        Confidential_Secret = 2,
        Public = 3,
        Strictly_Confidential = 4,
        help = 5
    };
    
    public enum StatusContent
    {
        Status1,
        Status2
    }
    
    public enum Accessibility
    {
        Accessibility1,
        Accessibility2
    }
    
    [Serializable]
    public class Classification
    {
        public ContentClassification? Choice { get; set; }
        public StatusContent? StatusOfContent { get; set; }
        public Accessibility? Accessibility { get; set; }
    
        public static bool Confirmation = true;
    
        public static IForm<Classification> BuildForm()
        {
            return new FormBuilder<Classification>()
                .Message("You want to")
                .Field(new FieldReflector<Classification>(nameof(Choice))
                       .SetNext((value, state) =>
                       {
                           var selection = (ContentClassification)value;
                           if (selection == ContentClassification.help)
                           {
                               Confirmation = false;
                               state.Accessibility = null;
                               state.StatusOfContent = null;
                           }
                           else
                           {
                               Confirmation = true;
                           }
                           return new NextStep();
                       }))
                  .Field(new FieldReflector<Classification>(nameof(StatusOfContent))
                       .SetActive(state => Confirmation))
                  .Field(new FieldReflector<Classification>(nameof(Accessibility))
                       .SetActive(state => Confirmation))
                .Build();
        }
    }
