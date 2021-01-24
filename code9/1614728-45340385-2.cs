    public class EncryptionFunctionClass {
    
        public string CaesarEncryptText(string inputText, int encryptionNumberShift) {
            var sb = new StringBuilder();
            foreach (var c in inputText) { sb.Append((char)(c + encryptionNumberShift)); }
            return sb.ToString();
        }
    }
