    var input = new StreamReader(Request.InputStream).ReadToEnd();
            var inputText = "PHBheW1lbnRSZXNwb25zZT48cmVzcG9uc2VDb2RlPjAwMDA8L3Jlc3BvbnNlQ29kZT48cmVzcG9uc2VDb2RlVGV4dD4wLVN1Y2Nlc3NmdWw8L3Jlc3BvbnNlQ29kZVRleHQ+PHJlc3BvbnNlU3VtbWFyeT5HUkVFTjwvcmVzcG9uc2VTdW1tYXJ5PjxwYXltZW50RXZlbnRJZGVudGlmaWVyPlRYTiAzNjM5PC9wYXltZW50RXZlbnRJZGVudGlmaWVyPjxMaXN0Pjxjb21wb25lbnRJRD5UWE4gMzYzOTwvY29tcG9uZW50SUQ+PGNsaWVudElEPkdPVERJU0UwNjwvY2xpZW50SUQ+PGJhbmtBdXRoQ29kZT5UOjEyMzQ8L2JhbmtBdXRoQ29kZT48YnV5bmV0VHhuSUQ+Mzc1PC9idXluZXRUeG5JRD48L0xpc3Q+PHBheW1lbnRJbnN0cnVtZW50UmVmPjwvcGF5bWVudEluc3RydW1lbnRSZWY+PG1hc2tlZENhcmROdW1iZXI+KioqKioqKioqKioqOTY4NjwvbWFza2VkQ2FyZE51bWJlcj48Y2FyZFR5cGU+TUFTVEVSQ0FSRDwvY2FyZFR5cGU+PGV4cGlyeURhdGU+MDMvMjAxNzwvZXhwaXJ5RGF0ZT48Y3VzdG9tRGF0YT4mbHQ7IVtDREFUQVsmbHQ7P3htbCB2ZXJzaW9uPSIxLjAiIGVuY29kaW5nPSJVVEYtOCI_Jmd0Ow0KJmx0O1RoaXN0bGVDdXN0b21EYXRhIHhtbG5zOnhzZD0iaHR0cDovL3d3dy53My5vcmcvMjAwMS9YTUxTY2hlbWEiIHhtbG5zOnhzaT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS9YTUxTY2hlbWEtaW5zdGFuY2UiJmd0Ow0KICAmbHQ7T3JkZXJJZCZndDtCVFBQMzYzOSZsdDsvT3JkZXJJZCZndDsNCiAgJmx0O0Ftb3VudCZndDsxMjAmbHQ7L0Ftb3VudCZndDsNCiZsdDsvVGhpc3RsZUN1c3RvbURhdGEmZ3Q7XV0mZ3Q7PC9jdXN0b21EYXRhPjwvcGF5bWVudFJlc3BvbnNlPg";
            inputText = ValidateBase64EncodedString(inputText);
    
            byte[] decodedBytes = Convert.FromBase64String(inputText);
    
            string xml = Encoding.UTF8.GetString(decodedBytes);
    
           private static string ValidateBase64EncodedString(string inputText)
            {
                string stringToValidate = inputText;
                stringToValidate = stringToValidate.Replace('-', '+'); // 62nd char of encoding
                stringToValidate = stringToValidate.Replace('_', '/'); // 63rd char of encoding
                switch (stringToValidate.Length % 4) // Pad with trailing '='s
                {
                    case 0: break; // No pad chars in this case
                    case 2: stringToValidate += "=="; break; // Two pad chars
                    case 3: stringToValidate += "="; break; // One pad char
                    default:
                        throw new System.Exception(
                 "Illegal base64url string!");
                }
    
                return stringToValidate;
            }
