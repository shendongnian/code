    public class MyClass : IDXDataErrorInfo
    {
       [Range(0,100)]
       [//Further custom validation]
       public int Id {get;set;}
       //Implement the Interface for your DXErrorProvider
       public void GetPropertyError(string propertyname, ErrorInfo info)
       {
          List<ValidationResult> errors = new List<ValidationResult>();
          if (propertyname.Equals(nameof(Id))
          {
            if (!Validator.TryValidateProperty(Id, new ValidationContext(this,null,null), errors))
            {
                string errorText = string.Empty;
                errors.ForEach(e => errorText += e.ErrorMessage);
 
                //This type set's the error-icon
                info.ErrorType = //The Type you want ErrorType.Warning for example
                info.ErrorText = errorText;
            }
          }
        }
           
           public void GetError(ErrorInfo info) {}  
    }
