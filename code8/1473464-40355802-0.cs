    static void Main(String[] args)
        {
            var strOne = "abcd";
            var strTwo = "bcd";
            var arrayOne = strOne.ToCharArray();
            var arrayTwo = strTwo.ToCharArray();
            var differentChars = arrayOne.Except(arrayTwo);
            foreach (var character in differentChars)
                Console.WriteLine(character);  //Will print a
        }
