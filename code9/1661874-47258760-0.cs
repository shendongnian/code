    using System.Diagnostics;
    Process proc = new Process();
    proc.StartInfo = new ProcessStartInfo()
    {
        CreateNoWindow = true,
        Verb = "print",
        // Path to your PDF
        FileName = pathToPDF
    };
    proc.Start();
