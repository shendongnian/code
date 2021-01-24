        public void GenerateHashOfString(string stringToHash)
        {
            hashCode = Encoding.ASCII.GetBytes(stringToHash);
        ==> hashCodeInStringForm = BitConverter.ToString(hashCode).Replace("-", string.Empty);
    
            linearHashArray.Add(hashCode, stringToHash);
        }
    
        public string FindHashCodeInDictionary(string StringToFind)
        {
        byte[] HashOfStringToFind = Encoding.ASCII.GetBytes(StringToFind);
    
        foreach (var hashCode in linearHashArray)
        {
            if (!linearHashArray.ContainsKey(HashOfStringToFind) && !linearHashArray.ContainsValue(StringToFind))
            {
            return "String and hash not found in array";
            }
        }
        return hashCodeInStringForm;
        }
