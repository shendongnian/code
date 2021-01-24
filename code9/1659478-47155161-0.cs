    class Program
    {
        static void Main(string[] args)
        {
            var row = "0A";
            var column = "A9Z";
            var rowsCount = 2;
            var columnsCount = 5;
            var rowCharArray =row.ToArray().Reverse().ToArray();
            var columnCharArray = column.ToArray().Reverse().ToArray();
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    columnCharArray = incrementChar(columnCharArray);
                    var currentColumn = string.Join("", columnCharArray.Reverse().ToArray());
                    var currentRow= string.Join("", rowCharArray.Reverse().ToArray());
                    Console.WriteLine(currentRow  + "-" + currentColumn);
                }
                columnCharArray = column.ToArray().Reverse().ToArray();
                rowCharArray= incrementChar(rowCharArray);
                Console.WriteLine("-------------------------------");
            }
            Console.ReadLine();
        }
        static char[] incrementChar(char[] charArray,int currentIndex=0)
        {
            char temp = charArray[currentIndex];
            if (charArray.Length -1 == currentIndex && (temp == '9' || temp == 'Z'))
                throw new Exception();
            temp++;
            if(Regex.IsMatch(temp.ToString(),"[A-Z]"))
            {
                charArray[currentIndex] = temp;
            }
            else
            {
                if (Regex.IsMatch(temp.ToString(), "[0-9]"))
                {
                    charArray[currentIndex] = temp;
                }
                else
                {
                    currentIndex++;
                    incrementChar(charArray, currentIndex);
                }
            }
            if (currentIndex != 0)
                charArray = resetChar(charArray, currentIndex);
            return charArray;
        }
        static char[] resetChar(char[] charArray,int currentIndex)
        {
            for (int i = 0; i < currentIndex; i++)
            {
                if (charArray[i] == 'Z')
                    charArray[i] = 'A';
                else if (charArray[i] == '9')
                    charArray[i] = '0';
            }
            return charArray;
        }
    }
