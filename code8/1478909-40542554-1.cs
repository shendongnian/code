     while (!inputFile.EndOfStream || count < gameArray.Length)
            {
                rawInput = inputFile.ReadLine();
                if(rawInput !=null)
                {
                  splitInput = rawInput.Split(delimiters);
                  MessageBox.Show(splitInput[0] + " // " + splitInput[1]); 
                }
            }
