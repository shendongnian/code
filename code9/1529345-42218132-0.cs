            string[]file= File.ReadAllLines(filePath); //Read your text file this way.
            int id = 1; //first id will be found at index 1 as mentioned by you.
            for (int i = 0; i < file.Length; i++)
            {
                if (i == id)
                {
                    //here is your id & Name
                    Console.WriteLine(file[i]);
                    if (file[id + 1] != null)//checking whether next index if null or not.
                        Console.WriteLine(file[id + 1]);
                    id += 4;//incremented as you said, it always be there in a sequence
                }
            }
