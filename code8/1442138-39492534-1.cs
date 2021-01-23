    private string DecodeFromUTFCode(string input){
        input = input.Replace("&#", "");
        StringBuilder decodedAnchor = new StringBuilder();
        StringBuilder currentUnicodeNum = new StringBuilder();
        bool isInNumber = false;
        for (int i = 0; i <= input.Length - 1; i++){
            if (Char.IsDigit(input[i])){
                isInNumber = true;
            }else{
                isInNumber = false;
                if (input[i] != ';') decodedAnchor.Append(input[i]);
            }
            if (isInNumber){
                currentUnicodeNum.Append(input[i]);
            }
            if ((input[i] == ';') || (i == input.Length - 1)){
                string decoded = char.ConvertFromUtf32(int.Parse(currentUnicodeNum.ToString()));
                decodedAnchor.Append(decoded);
                currentUnicodeNum.Clear();
            }
        }
        return decodedAnchor.ToString();
    }
