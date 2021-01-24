    Process process = new Process();
    process.StartInfo.FileName = "C:/temp/toe/Tessnet OCR Engine.exe";
    process.StartInfo.Arguments = workPath + " N && N";
    
    // workPath is the directory where all images are stored
    // N -> Numeral Only, A if all
    // && -> Separator to define each the termination of every image's text
    // N -> No Echo of results Y-> Show results on console and wait for user input.
    
    process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
    process.Start();
    process.WaitForExit();
                    
    string res = File.ReadAllText(workPath.Text+"/result/result.txt");
    string[] result;
    string[] stringSeparators = new string[] { "&&" };
    result = res.Split(stringSeparators, StringSplitOptions.None);
