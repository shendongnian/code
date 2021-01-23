            anObject[] alternative = new anObject[5]; // From this will be copied
            anObject[] storage = new anObject[5]; //And here it will be copied to
            /* display the alternative anObject array (via loop)*/
            int storageIndex = 0;
            // Get the name
            string userInput = Console.ReadLine(); // Or use any other way you want
            // Iterate over initial aray
            for (int i = 0; i < alternative.Length; i++)
            {
                if(alternative != null) // Make sure it exists
                {
                    if (userInput == alternative[i].Name)
                        storage[storageIndex++] = alternative[i];
                }
            }
