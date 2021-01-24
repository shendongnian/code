    public class TicketNumber
    {
        public string Type { get; set; } // Maybe you want to have different types of ticket?
        public string AlphaPrefix { get; set; }
        public string NumericPrefix { get; set; }
        public TicketNumber()
        {
            this.AlphaPrefix = "AAA";
            this.NumericPrefix = "0001";
        }
        public void Increment()
        {
            int num = int.Parse(this.NumericPrefix);
            if (num + 1 >= 9999)
            {
                num = 1;
                int i = 2; // We are assuming that there are only 3 characters
                bool isMax = this.AlphaPrefix == "ZZZ";
                if (isMax)
                {
                    this.AlphaPrefix = "AAA"; // reset
                }
                else
                {
                    while (this.AlphaPrefix[i] == 'Z')
                    {
                        i--;
                    }
                    char iChar = this.AlphaPrefix[i];
                    StringBuilder sb = new StringBuilder(this.AlphaPrefix);
                    sb[i] = (char)i++;
                    this.AlphaPrefix = sb.ToString();
                }
            }
            else
            {
                num++;
            }
            this.NumericPrefix = num.ToString().PadLeft(4, '0');
        }
        public override string ToString()
        {
            return this.AlphaPrefix + this.NumericPrefix;
        }
    }
