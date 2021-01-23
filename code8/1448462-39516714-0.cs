    public class BasicPasswordPolicyValidator
        {
            /// <summary>
            ///     Minimum required length
            /// </summary>
            public int RequiredLength { get; set; }
    
            /// <summary>
            ///     Require a non letter or digit character
            /// </summary>
            public bool RequireNonLetterOrDigit { get; set; }
    
            /// <summary>
            ///     Require a lower case letter ('a' - 'z')
            /// </summary>
            public bool RequireLowercase { get; set; }
    
            /// <summary>
            ///     Require an upper case letter ('A' - 'Z')
            /// </summary>
            public bool RequireUppercase { get; set; }
    
            /// <summary>
            ///     Require a digit ('0' - '9')
            /// </summary>
            public bool RequireDigit { get; set; }
    
            public virtual ValidationResult Validate(string item)
            {
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var errors = new List<string>();
                if (string.IsNullOrWhiteSpace(item) || item.Length < RequiredLength)
                    errors.Add("Password is too short");
                if (RequireNonLetterOrDigit && item.All(IsLetterOrDigit))
                    errors.Add("Password requires non letter or digit");
                if (RequireDigit && item.All(c => !IsDigit(c)))
                    errors.Add("Password requires digit");
                if (RequireLowercase && item.All(c => !IsLower(c)))
                    errors.Add("Password requires lowercase");
                if (RequireUppercase && item.All(c => !IsUpper(c)))
                    errors.Add("Password requires uppercase");
    
                if (errors.Count == 0)
                    return new ValidationResult
                    {
                        Success = true,
                    };
    
                return new ValidationResult
                {
                    Success = false,
                    Errors = errors
                };
            }
    
            /// <summary>
            ///     Returns true if the character is a digit between '0' and '9'
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public virtual bool IsDigit(char c)
            {
                return c >= '0' && c <= '9';
            }
    
            /// <summary>
            ///     Returns true if the character is between 'a' and 'z'
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public virtual bool IsLower(char c)
            {
                return c >= 'a' && c <= 'z';
            }
    
            /// <summary>
            ///     Returns true if the character is between 'A' and 'Z'
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public virtual bool IsUpper(char c)
            {
                return c >= 'A' && c <= 'Z';
            }
    
            /// <summary>
            ///     Returns true if the character is upper, lower, or a digit
            /// </summary>
            /// <param name="c"></param>
            /// <returns></returns>
            public virtual bool IsLetterOrDigit(char c)
            {
                return IsUpper(c) || IsLower(c) || IsDigit(c);
            }
        }
