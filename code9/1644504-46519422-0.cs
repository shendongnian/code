    using (var reader = new StreamReader(@"input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var inputText = reader.ReadLine();
                    var splitText = inputText.Split(',');
                    File.AppendAllLines(splitText[1] + ".txt", new List<string> {splitText[0]});
                }
            }
