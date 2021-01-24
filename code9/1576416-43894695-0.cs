    namespace ConsoleApp6
    {
        using System;
        using System.Text;
    
        using System.Text.RegularExpressions;
    
        internal static class Program
        {
            private static string ValidatePasswordComplexity(string newPassword)
            {
                StringBuilder errorMessage = new StringBuilder();
    
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                var criteria = 0;
    
                if (hasUpperChar.IsMatch(newPassword))
                    criteria++;
                else
                {
                    errorMessage.Append("Password should contain at least one English uppercase letter (A through Z).");
                    errorMessage.AppendLine();
                }
    
                if (hasLowerChar.IsMatch(newPassword))
                    criteria++;
                else
                {
                    errorMessage.Append("Password should contain at least one English lowercase letter (a through z).");
                    errorMessage.AppendLine();
                }
    
                if (hasNumber.IsMatch(newPassword))
                    criteria++;
                else
                {
                    errorMessage.Append("Password should contain at least one numeric value (0 through 9).");
                    errorMessage.AppendLine();
                }
    
                if (hasSymbols.IsMatch(newPassword))
                    criteria++;
                else
                {
                    errorMessage.Append("Password should contain at least one non-alphabetic character (for example: !, $, #, %).");
                }
    
                if (criteria >= 3)
                    return "Success";
                else
                    return errorMessage.ToString();
            }
    
            internal static void Main()
            {
                var text = ValidatePasswordComplexity("Abcdefg");
    
                Console.WriteLine(text);
                Console.ReadLine();
            }
        }
    }
