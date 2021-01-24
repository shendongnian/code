    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.IO;
    namespace Text
     {
     class Program
     {
       static void Main(string[] args)
       {
         //create variable
         bool valid = false;
         //start loop
         //when ever the valid boolean evaluates as false the loop continues
         // when its true it will kick out of the loop
         while(valid == false)
         {
             \\create input box and store variable
             string input = Microsoft.VisualBasic.Interaction.InputBox("Please Type In The Number", "Type");
             \\check if variable is 'exit' if it is set boolean to true
             if (input == "exit")
             {
                  valid = true;
             }
             \\otherwise its false and the loop will continue
             else
             {
                  valid = false
             }
          }
       }
     }
     }
