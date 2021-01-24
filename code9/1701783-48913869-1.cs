    public class ValuesLengthAttribute : ValidationAttribute
        {
            public int MaximumLength { get; set; }
            public override Boolean IsValid(object value)
            {
                Boolean isValid = true;
                var list = value as List<TextPair>;
                if (list != null && list.Count>0)
                    foreach (var item in list)
                    {
                        if (item.Value.Length > MaximumLength)
                            isValid = false;
                    }
    
                return isValid;
            }
        }
