    public int caesarEncryptText(string inputText, int encryptionNumberShift)
    {
            textConvertedToArray.Add(inputText);
            char test2 = '';
            foreach (char c in inputText.ToString().ToCharArray())
            {
                int i = 0;
                test2 = c;
                test1 = test2;
                if ((char)c + encryptionNumberShift >= 24)
                {
                    isReturn = true;
    
                    test2 = c;
                    charToMessageBox.Add(c.ToString());
    
                }
                else
                {
                    isNotReturn = true;
                    test2 = c;
                    charToMessageBox.Add(c.ToString());
                }
    
            }
    
           //Now you can use test2 here
    
    }
