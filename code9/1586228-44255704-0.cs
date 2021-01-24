    static void Main(string[] args)
            {
                var input = "1 29 39 4 59";
    
                var outputStack = new Stack<string>();
    
                while (!string.IsNullOrWhiteSpace(input))
                {
                    var splitIndex = input.IndexOf(" ", StringComparison.Ordinal);
                    if (splitIndex < 0)
                    {
                        outputStack.Push(input);
                        input = string.Empty;
                    }
                    else
                    {
                        outputStack.Push(input.Substring(0, splitIndex));
                        input = input.Substring(++splitIndex, input.Length - splitIndex);
                    }
                }
                while (outputStack.Count > 0)
                    Console.WriteLine(outputStack.Pop());
                Console.ReadKey();
            }
