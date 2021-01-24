    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"<[a-zA-Z-0-9]+\s?>([\w]+)<\/[a-zA-Z-0-9]+\s?>";
            // the example you gave
            string input = @"<T1>value1</T1>
                <T1001>value2</T1001>
                <T2000 />
                <SomeValue>value1</SomeValue >
                <A2ndValue>value2</A2ndValue >";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                // the output
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
