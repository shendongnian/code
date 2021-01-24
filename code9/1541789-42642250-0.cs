    string inputString = "abc123$%ab12";
    
    var results = inputString.Select(x => char.IsLetter(x) ? 'A' :
                                         char.IsDigit(x) ? 'D' : 'S');
    StringBuilder outPutBuilder = new StringBuilder();
    char previousChar = results.First();
    int charCount = 0;
    foreach (var item in results)
    {
        switch (item)
        {
            case 'A':
                if (previousChar == 'A')
                {
                    charCount++;
                }
                else
                {
                    outPutBuilder.Append(previousChar.ToString() + charCount);
                    charCount = 1;
                }
                break;
            case 'D':
                if (previousChar == 'D')               
                    charCount++;               
                else
                {
                    outPutBuilder.Append(previousChar.ToString() + charCount);
                    charCount = 1;
                }
                break;
            default:
                if (previousChar == 'S')
                   charCount++;               
                else
                {
                    outPutBuilder.Append(previousChar.ToString() + charCount);
                    charCount = 1;
                }
                break;
        }
        previousChar = item;
    }
    outPutBuilder.Append(previousChar.ToString() + charCount);
