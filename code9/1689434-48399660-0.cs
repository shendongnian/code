            Console.WriteLine("\nWrite a word/sentence: ");
            char[] myString = Console.ReadLine().ToCharArray();
            Console.Write("Type the character you would like to replace: ");
            char myCharacter = Console.ReadLine().ToCharArray()[0];
            int[] findIndex = new int[myString.Length];
            int indexCount = 0;
            for (int i = 0; i < myString.Length; i++)
            {
                if (myString[i] == myCharacter)
                    findIndex[indexCount++] = i;
            }
            for (int i = 0; i < indexCount; i++)
            {
                Console.Write(findIndex[i]);
            }
