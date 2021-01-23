    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace EditText
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Import text from file to an array.
                string[] myArray = File.ReadAllLines("text1.txt");
                //This is what will be written into the text file.
                string myFileText = "";
            
                //Loop through the array
                for(int i = 0; i<myArray.Length; i++)
                {
                    //Du the change you want here
                    string myString = "237" + myArray[i] + "#";
                    //Add the result to the string you will write to the file
                    myFileText += myString;
                    myFileText += Environment.NewLine;
                }
                //Write the text to the file. 
                File.WriteAllText("text1.txt", myFileText);
                //Done
            }
        }
    }
