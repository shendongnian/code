    public class EncryptionFunctionClass {
        
        private char c;　//Default value of '\0'    
        
        public char ShadowingExample(string inputText, int encryptionNumberShift) {
        foreach (var c in inputText) {
            //Play with `c` here will not affect private char c declared above.
            var anotherChar = (char)(c + 24);//Etc..
        }
        return c;←Still '\0'!!!!
    } 
          
        public string CaesarEncryptText(string inputText, int encryptionNumberShift) {
            var sb = new StringBuilder();
            foreach (var c in inputText) { sb.Append((char)(c + encryptionNumberShift)); }
            return sb.ToString();
        }
    }
