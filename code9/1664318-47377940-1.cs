           for (int i = 0; i < result.Length; i = word)
            {
                if (keyLength > 0)
                {
                    key += result.Substring(word, 1);
                    word++;
                    keyLength--;
                }
                if (textLength > 0)
                {
                    for (int k = 0; k < step; k++)
                    {
                        try
                        {
                            text += result.Substring(word, 1);
                            word++;
                            textLength--;
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Text : " + text);
            Console.Write("Key : " + key);
            Console.ReadKey();
