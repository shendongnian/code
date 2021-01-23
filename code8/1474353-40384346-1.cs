            string test; //your input string
            int j;  //variable that holds the slide content length
            int max_lines = 10;  //desired maximum amount of lines per slide
            int max_characters = 1000; //desired maximum amount of characters
            char[] input = test.ToCharArray();  //convert input string into an array of characters
            string slide_content;    //variable that will hold the output of each single slide
            while (input.Length > 0)
            {
                //reset slide content and length
                slide_content = string.Empty;
                j = 0;
                //loop through the input string and get a 'j' amount of characters
                while ((slide_content.Split('\n').Length < max_lines) && (j < max_characters))
                {
                    j = j + 1;
                    slide_content = new string(input.Take(j).ToArray());
                }
                //Output slide content
                Console.WriteLine(slide_content);
                Console.WriteLine("=================== END OF THE SLIDE =====================");          
                //Remove the previous slide content from the input string
                input = input.Skip(j).ToArray();       
            }
            Console.Read();
