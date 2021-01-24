    var startInfo = new ProcessStartInfo();
    switch (ThermoCS.PlatformCheck.RunningPlatform())
    {
        case ThermoCS.PlatformCheck.Platform.Windows:
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Environment.CurrentDirectory + "\\ThermoCS\\" + item.Key + ".exe";
            if (item.Key.Contains("1"))
            {
                startInfo.Arguments = Model;
            }
            else
            {
                startInfo.Arguments = Model + " " + MixRule;
            }
            break;
        case ThermoCS.PlatformCheck.Platform.Linux:
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            var ldc = "LD_LIBRARY_PATH=" + Environment.CurrentDirectory + "/ThermoCS/; export LD_LIBRARY_PATH";
            var scriptl = new StringBuilder();
            scriptl.AppendLine("#!/bin/bash");
            scriptl.AppendLine("cd '" + Environment.CurrentDirectory + "'");
            scriptl.AppendLine(ldc);
            scriptl.AppendLine("chmod +x ThermoCS/" + item.Key);
            if (item.Key.Contains("1"))
            {
                scriptl.AppendLine("./ThermoCS/" + item.Key + " " + Model);
            }
            else
            {
                scriptl.AppendLine("./ThermoCS/" + item.Key + " " + Model + " " + MixRule);
            }
            var filepathl = Path.GetTempFileName();
            File.WriteAllText(filepathl, scriptl.ToString());
            Process.Start("/bin/bash", "-c \" chmod +x " + filepathl + " \"");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "xterm";
            startInfo.Arguments = "-e '" + filepathl + "'";
            break;
        case ThermoCS.PlatformCheck.Platform.Mac:
            var basedir = Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.FullName;
            var ldcosx = "export DYLD_LIBRARY_PATH=" + basedir + "/Contents/MonoBundle/ThermoCS/";
            var script = new StringBuilder();
            script.AppendLine("#!/bin/bash");
            script.AppendLine("cd '" + basedir + "'");
            script.AppendLine(ldcosx);
            script.AppendLine("chmod +x Contents/MonoBundle/ThermoCS/" + item.Key);
            if (item.Key.Contains("1"))
            {
                script.AppendLine("./Contents/MonoBundle/ThermoCS/" + item.Key + " " + Model);
            }
            else
            {
                script.AppendLine("./Contents/MonoBundle/ThermoCS/" + item.Key + " " + Model + " " + MixRule);
            }
            var filepath = Path.GetTempFileName();
            File.WriteAllText(filepath, script.ToString());
            Process.Start("/bin/bash", "-c \" chmod +x " + filepath + " \"");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.FileName = "open";
            startInfo.Arguments = "-a Terminal.app " + filepath;
            break;
    }
    Process proc = Process.Start(startInfo);
