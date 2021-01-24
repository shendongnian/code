    public class MyFormViewModel{
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress] or [RegularExpression(*expression here*)]
    Public String Email {Get;Set;}
    }
