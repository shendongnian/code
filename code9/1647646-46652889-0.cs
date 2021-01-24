    using System;
    using System.Data.Entity.Design.PluralizationServices;
    using System.Globalization;
    
    namespace WindowsFormsApp1
    {
        internal class MyClass
        {
            private static void CheckParameters(string word, int count)
            {
                if (string.IsNullOrWhiteSpace(word))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(word));
    
                if (count <= 0)
                    throw new ArgumentOutOfRangeException(nameof(count));
            }
    
            public static string GetLabel1(string word, int count)
            {
                CheckParameters(word, count);
    
                var label = $"{word}{(count > 1 ? "s" : string.Empty)}";
    
                return label;
            }
    
            public static string GetLabel2(string word, int count)
            {
                CheckParameters(word, count);
    
                // TODO this should be a member instead of being instantiated every time
                var service = PluralizationService.CreateService(CultureInfo.CurrentCulture);
    
                var label = count > 1 ? service.Pluralize(word) : service.Singularize(word);
    
                return label;
            }
        }
    }
