      public interface IDICOMElement
      {
        Tag Tag { get; set; }
    
        Type DatType { get; }
    
        object DData { get; set; }
    
        ICollection DData_ { get; set; }
      }
