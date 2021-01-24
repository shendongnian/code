    String sentence = "Hello my name is Bob, and I'm testing the line length in this program.";
    String[] words = sentence.Split();
                
    //Assigning first word here to avoid begining with a space.
    String line = words[0];
    
                //Starting at 1, as 0 has already been assigned
                for (int i = 1; i < words.Length; i++ )
                {
                    //Test for line length here
                    if ((line + words[i]).Length < 10)
                    {
                        line = line + " " + words[i];
                    }
                    else
                    {
                        Console.WriteLine(line);
                        line = words[i];
                    }
                }
    
                Console.WriteLine(line);
