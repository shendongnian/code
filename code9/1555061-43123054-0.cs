        string a = "aBcdef3213BBBBB0913456";
        var charList = a.ToCharArray();
        string newString = string.Empty;
        foreach (var letter in charList.Reverse())
        {
            var number = 0;
            if (Int32.TryParse(letter.ToString(), out number))
            {
                newString = string.Format("{0}{1}", letter, newString);
            }
            else
            {
                break;
            }
        }
