    string File1 = "AMD Intel Skylake Processors Graphics Cards Nvidia Architecture Microprocessor Skylake SandyBridge KabyLake";
    string File2 = "Graphics Nvidia";
    string[] Results = File1.Split(" ".ToCharArray()).Except(File2.Split(" ".ToCharArray())).OrderByDescending(s => s.Length).Take(10).ToArray();
    for (int i = 0; i < Results.Length; i++)
    {
         Console.WriteLine(Results[i] + " " + Regex.Matches(File1, Results[i]).Count);
    }
