    using System;
    using System.Collections.Generic;
    using System.IO;
    class Solution {
        static void Main(String[] args) {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            int N;
            string dumbAssInput, name, phoneNum;
            
            
            N = Convert.ToInt32(Console.ReadLine());
            
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            for(int index = 0; index < N; ++index)
            {
                dumbAssInput = Console.ReadLine();
                string[] keyAndValue = dumbAssInput.Split(' ');
                name = keyAndValue[0];
                phoneNum = keyAndValue[1];
                phoneBook.Add(name, phoneNum);
            }
            
            for(int index = 0; index < N; ++index)
            {
                name = Console.ReadLine();
                if(phoneBook.ContainsKey(name) == true)
                    Console.WriteLine("{0}={1}",name, phoneBook[name]);
                else
                    Console.WriteLine("Not found");
            }
            
            
        }
    }
