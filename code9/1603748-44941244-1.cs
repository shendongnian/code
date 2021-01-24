    buildProgress.Enabled = true;
    buildProgress.Maximum = lineCount;
    for (int ctr = 0; ctr < lineCount; ctr++)
    {   
        String outputPath = @"Q:\";
        StreamReader reader;
        String outputLine;
        console = new Process();
        console.StartInfo.FileName = "cmd.exe";
        console.StartInfo.UseShellExecute = false;
        console.StartInfo.CreateNoWindow = true;
        console.StartInfo.RedirectStandardInput = true;
        console.StartInfo.RedirectStandardOutput = true;
        console.StartInfo.RedirectStandardError = true;
        console.Start();
        using (StreamWriter sw = console.StandardInput)
        {
            sw.AutoFlush = true;
            console.StandardInput.AutoFlush = true;
            if (sw.BaseStream.CanWrite)
            {
                sw.WriteLine(@"Q:\");       
                sw.WriteLine("msbuild /property:OutputPath=" + outputPath + @";OutputType=Library " + lines[ctr]);
                sw.Flush();
            }
            sw.Close();
        }
        reader = console.StandardOutput;
        outputLine = reader.ReadToEnd();
        console.WaitForExit();
        //if (console.HasExited)
        //{ 
            Console.Write(outputLine);
            //outputTextBox.Text += outputLine;
            pathToLog = @"Q:\" + fileList[ctr];
            File.Create(pathToLog).Dispose();
            File.WriteAllText(pathToLog, outputLine);
            buildProgress.Value = ctr;
            string[] readThatLog = File.ReadAllLines(pathToLog);
            foreach(string line in readThatLog)
            {
                if (line == "Build succeeded.")
                { 
                    outputTextBox.AppendText(lines[ctr]);
                    outputTextBox.AppendText(Environment.NewLine + line);
                    outputTextBox.AppendText(Environment.NewLine + Environment.NewLine);
                }
                else if (line == "Build FAILED.")
                {
                    outputTextBox.AppendText(lines[ctr]);
                    outputTextBox.AppendText(Environment.NewLine + line);
                    outputTextBox.AppendText(Environment.NewLine + Environment.NewLine);
                }
            }
        //}
    }
    buildProgress.Value = 0;
    buildProgress.Enabled = false;
    Console.WriteLine("\n\n\n\nDONE!!!");
