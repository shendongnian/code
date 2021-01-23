    interface ICanBeUsedOnlyByA {
      int Data_One { get; set; }
    }
    interface ICanBeUsedOnlyByB {
      int Data_Two { get; set; }
    }
    
    class DataClass : ICanBeUsedOnlyByA, ICanBeUsedOnlyByB {
    }
