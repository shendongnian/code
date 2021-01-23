    class Program
    {
        
        static void Main(string[] args)
        {
            List<string> digits = new List<string>() {
                                  "0000","0001","0010","0011","0100","0101","0110","0111",
                                  "1000","1001","1010","1011","1100","1101","1110","1111"
                              };
            string input = "0100-0000 0000-0000 0011-0000 0001-1001";
            byte[] bytes = input.Split(new char[] { '-', ' ' }).Select(x => (byte)digits.IndexOf(x)).ToArray();
            ulong number = BitConverter.ToUInt64(bytes,0);
            Console.WriteLine(number);
            Console.ReadLine();
        }
    }
    
}
