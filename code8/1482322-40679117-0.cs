    public static string validate(List<SomeErrorMessageThing> validationErrors) //Whatever type var error is
            {
                List<string> errorList = new List<string>();
    
                foreach (SomeErrorMessageThing error in validationErrors)
                {
                    errorList.Add(error.ValidationErrors.FirstOrDefault().ErrorMessage);
                }
    
                if (errorList.Count > 0)
                {
                    string errors = string.Join("\n", errorList);
                    return errors;
                }
                return "";
            }
