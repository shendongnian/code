            if (reader.ReadToFollowing("ranking"))
            {
                do
                {
                    Console.WriteLine("Ranking: " + reader.GetAttribute("name"));
                    if (reader.ReadToDescendant("stat"))
                    {
                        do
                        {
                            Console.WriteLine("Stat: " + reader.GetAttribute("name"));
                        } while (reader.ReadToNextSibling("stat"));
                    }
                } while (reader.ReadToNextSibling("ranking"));
            }
