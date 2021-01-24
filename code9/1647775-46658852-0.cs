     class Program
        {
            static void Main(string[] args)
            {
                var inputString = @"List of devices attached\r\n9887bc314\tdevice\r\n12n1n2nj1jn2\tdevice\r\n\r\n";
                var chunks = inputString.Split(@"\tdevice");
    
                string result = "[";
    
                for (int i = 0; i < chunks.Length-1; i++)
                {
                    int indexReturn = chunks[i].IndexOf(@"\r\n");
                    if (indexReturn >= 0)
                        result += chunks[i].Substring(indexReturn + 4, chunks[i].Length - indexReturn - 4) + ",";
                }
                result = result.Remove(result.Length - 1);
                result += "]";
            }
        }
