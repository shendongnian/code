     public String GetValidNumber(String numberToValid)
        {
            String validNumber = "";
            bool isValidChar = false;
            try
            {
                for (int i = 0; i < numberToValid.Length; i++)
                {
                    isValidChar = checkAsciiChar(numberToValid[i].ToString());
                    if (isValidChar)
                        validNumber += numberToValid[i];
                }
                return validNumber;
            }
            catch (Exception ex){}            
        }
        private bool checkAsciiChar(string c)
        {
            bool isValid = false;
            try
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(c);
                for (int i = 48; i <= 57; i++)
                {
                    if (asciiBytes[0] == i)
                        isValid = true;
                }
                for (int i = 65; i <= 90; i++)
                {
                    if (asciiBytes[0] == i)
                        isValid = true;
                }
                for (int i = 97; i <= 122; i++)
                {
                    if (asciiBytes[0] == i)
                        isValid = true;
                }
                if (asciiBytes[0] == 250)
                    isValid = true;
                return isValid;
            }
            catch (Exception ex){}            
        }
