    using Microsoft.Office.Interop.Word;
    using System;
    using System.Collections.Generic;
    using System.Text;
    ...
    Application wordApp = new Application();
    object miss = System.Reflection.Missing.Value;
    object readOnly = true;
    object filename = "...\Test.docx";
    Document doc = wordApp.Documents.Open(ref filename, ref miss, ref 
    readOnly,...);
    
    List<string> boldList = new List<string>();
    
    foreach (Range rng in doc.StoryRanges)
         foreach (Range rngWord in rng.Words)
             if (rngWord.Bold != 0)
                 boldList.Add(rngWord.Text);             
    
         foreach (var item in boldList)
             Console.WriteLine(item);
    
         Console.ReadKey();
         wordApp.Quit();
