    using System;
    using System.IO;
    using System.Diagnostics;
    // ...
        byte[] resourceFile = Properties.Resources.Newspaper_PC_13_12_2013;
        string destination = Path.Combine(Path.GetTempPath(), "Newspaper_PC_13_12_2013.pdf");
        System.IO.File.WriteAllBytes(destination, resourceFile);
        Process.Start(destination);
