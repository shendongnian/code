                for (int i = 0; i < badWords.Length; i++)
            {
                if (msg.Content.Contains(badWords[i]))
                {
                    Console.WriteLine("true");
                    if (wordOffences.ContainsKey(msg.Author.ToString()))
                    {
                        wordOffences[msg.Author.ToString()] += 1;
                        Console.WriteLine("if");
                        Console.WriteLine(wordOffences[msg.Author.ToString()]);
                        File.WriteAllText(@"c:\Users\me\Desktop\real.json", JsonConvert.SerializeObject(wordOffences));
                        if (wordOffences[msg.Author.ToString()] >= 3)
                        {
                            Console.WriteLine("really true");
                            await m.Channel.SendMessageAsync("@Staff have been notified. Hey buddy watch your language! This is offence: " + wordOffences[msg.Author.ToString()]);
                        }
                        else
                        {
                            Console.WriteLine("y");
                            await m.Channel.SendMessageAsync("Hey buddy watch your language! This is offence: " + wordOffences[msg.Author.ToString()]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("runmf");
                        wordOffences.Add(msg.Author.ToString(), 1);
                        Console.WriteLine(wordOffences[msg.Author.ToString()]);
                        await m.Channel.SendMessageAsync("Hey buddy watch your language! This is offence: " + wordOffences[msg.Author.ToString()]);
                        File.WriteAllText(@"c:\Users\me\Desktop\real.json", JsonConvert.SerializeObject(wordOffences));
                    }
                    i = badWords.Length;
                }
