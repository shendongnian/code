    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    
    using System.Configuration;
    using System.Collections.Specialized;
    using System.Text.RegularExpressions;
    
    namespace WebApplication1.Attributes
    {
        [AttributeUsage(AttributeTargets.Class)]
        public class UniversalValidatorAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
            {
                if (value == null)
                    return ValidationResult.Success;
    
                var validatorConfig = (NameValueCollection)ConfigurationManager.GetSection("CustomConfig/UniversalValidatorConfig");
                var validationRules = validatorConfig.AllKeys
                    .Select(key => new { PropertyName = key, ValidationRule = validatorConfig.GetValues(key).FirstOrDefault() })
                    .ToList();
    
                var errorMessages = new List<string>(validationRules.Count);
    
                foreach (var validationRule in validationRules)
                {
                    var property = value.GetType().GetProperty(validationRule.PropertyName);
                    if (property == null) continue;
    
                    var propValue = property.GetValue(value)?.ToString();
                    var regEx = new Regex(validationRule.ValidationRule, (RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
                    var isValid = regEx.IsMatch(propValue);
    
                    if (!isValid)
                        errorMessages.Add(FormatErrorMessage(validationRule.PropertyName));
                }
                
    
                if (errorMessages.Any())
                    return new ValidationResult(string.Join("\r\n", errorMessages));
    
                return ValidationResult.Success;
            }
        }
    }
