    [Flags]
    public enum EFileFormat
    {
        Rtf = 0x1,
        Word = 0x2,
        Pdf = 0x4,
        Html = 0x8,
        Txt = 0x16
    }
    ...
    // this will be equal to only word
    var word = EFileFormat.Word;
    // this will be equal to every value except word    
    var notWord = ~EFileFormat.Word;
    // this will be equal to Html and Pdf
    var value = EFileFormat.Html | EFileFormat.Pdf;
    // this will be equal to Html
    var html = value - EFileFormat.Pdf;
    // this will check if a value has word in it
    if(notWord == (notWord & EFileFormat.Word))
    {
       // it will never reach here because notWord does not contain word,
       // it contains everything but word.
    }
   
