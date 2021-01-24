    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    namespace Test {
        class Program {
            static void Main(string[] args) {
                var bodyXmlPart = @"Hi please see below client <?xml version=""1.0"" encoding=""UTF-8""?>" +
                "<ac_application>" +
                "    <primary_applicant_data>" +
                "       <first_name>Ross</first_name>" +
                "       <middle_name></middle_name>" +
                "       <last_name>Geller</last_name>" +
                "       <ssn>123456789</ssn>" +
                "    </primary_applicant_data>" +
                "</ac_application> thank you, \n john ";
    
                Regex regex = new Regex(@"(?<pre>.*)(?<xml>\<\?xml.*</ac_application\>)(?<post>.*)", RegexOptions.Singleline);
                var match = regex.Match(bodyXmlPart);
                if (match.Success) {
                    Debug.WriteLine($"pre={match.Groups["pre"].Value}");
                    Debug.WriteLine($"xml={match.Groups["xml"].Value}");
                    Debug.WriteLine($"post={match.Groups["post"].Value}");
                }
            }
        }
    }
