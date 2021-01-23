        class MyColor
        {
            private byte red;
            private byte green;
            private byte blue;
            private byte alpha;
            public MyColor(byte red, byte green, byte blue, byte alpha)
            {
                this.red = red;
                this.green = green;
                this.blue = blue;
                this.alpha = alpha;
            }
            public byte Red
            {
                get
                {
                    return this.red;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                byte red;
                while (true)
                {
                    Console.WriteLine("Input a byte in the range of 0 to 255 - for Red:");
                    string line = Console.ReadLine();
                    if (line.Length > 3 || !byte.TryParse(line, out red))
                    {
                        Console.WriteLine("Invalid Entry - try again");
                        Console.WriteLine("Input a byte in the range of 0 to 255 - for Red:");
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
