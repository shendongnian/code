    Process p = new Process();
    p.StartInfo = new ProcessStartInfo("cscript");
    p.startInfo.UseShellExecute = false;
    p.startInfo.RedirectStandardOutput= true;
    p.startInfo.RedirectStandardError= true;
    var outputWriter = new StringWriter();
    p.OutputDataReceived += (sender, args) => outputWriter.WriteLine(args.Data);
    var errorWriter = new StringWriter();
    p.ErrorDataReceived += (sender, args) => errorWriter.WriteLine(args.Data)
    p.StartInfo.Arguments = string.Format("//Nologo C:\\scripts\myscript.vbs "\"{0} \"{1}"",x,y);
    OutputWriter.NewLine ="";
    errorWriter.NewLine ="";
    p.Start();
    p.BeginOutputReadLine();
    p.BeginErrorReadLine();
    p.WaitForExit();
    
    //Just to see output and errors coming back.
    Console.WriteLine(outputWriter.GetStringBuilder().ToString());
    Console.WriteLine(errorWriter.GetStringBuilder().ToString());
    p.Close();
    p.Dispose();
