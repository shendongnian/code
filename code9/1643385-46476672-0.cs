    using System;
    using System.Text;
    
    class MainClass
    {
        public static void Main()
        {
            string inputText = "John12Fitzgerald34Kennedy";
            StringBuilder returnText = new StringBuilder();
    
            foreach (char singleChar in inputText)
            {
                if ((int)singleChar >= 0x30 && (int)singleChar <= 0x39)
                    returnText.Append(singleChar);
            }
    
            Console.WriteLine(returnText);
            Console.ReadLine();
        } 
    }
