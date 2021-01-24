        // Call the function once with a sequentially increasing number (e.g. based on an identity column in SQL Server, or a variable that is persisted and incremented) 
        // Lets call the string returned by this function call subpartUnique 
        // Call the function a second time for randomly generated number (e.g. using Random.Next() and any seed) 
        // Let's call this second string subpartRandom 
        // Let the final target string's length be N 
        // Take all characters from subpartUnique, take only (N - subpartRandom.Length) characters from subpartRandom and concatenate them 
        static String ConvertToString(Int32 input)
        {
            // List of characters allowed in the target string 
            String[] allowedList = new String[] {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
                "U", "V", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            StringBuilder result = new StringBuilder(input.ToString().Length);
            Int32 allowedSize = allowedList.Length;
            Int32 moduloResult;
            while (input > 0)
            {
                moduloResult = input % allowedSize;
                input /= allowedSize;
                result.Insert(0, allowedList[moduloResult]);
            }
            return result.ToString();
        }
