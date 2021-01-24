    namespace StackOverFlow {
    
        using System;
        using System.Text;
    
        internal class Program {
    
            private static void Main(string[] args) {
                Console.WriteLine(Caesar("Hello, World", 13));
                Console.WriteLine(Caesar("Äste in Österreich sind übermäßig große Äste!", 7));
                Console.WriteLine(Caesar("z", 5));
                Console.WriteLine(Caesar("1234567890", 283));
                Console.WriteLine(Caesar("KEIN LIMIT!!!", 940));
            }
    
            private static string Caesar(string input, int n) {
                n = n % 94;
                var stringBuilder = new StringBuilder(input);
                stringBuilder.Replace("Ä", "Ae").Replace("Ü", "Ue").Replace("Ö", "Oo").Replace("ß", "ss").Replace("ä", "ae").Replace("ü", "ue").Replace("ö", "oe");
    
                var cipher = new StringBuilder();
    
                for(var i = 0; i < stringBuilder.Length; i++) {
                    var code = ((int)stringBuilder[i]);
                    char crypt;
                    if(code >= 33 && code <= (126 - n)) { code = code + n; crypt = Convert.ToChar(code); }
                    else if(code > (126 - n) && code <= 126) { code = ((code + n) % 94); crypt = Convert.ToChar(code); }
                    else { crypt = stringBuilder[i]; }
                    cipher.Append(crypt);
                }
                return cipher.ToString();
            }
        }
    }
