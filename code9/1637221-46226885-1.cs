    using System.Threading;
    for (int i = 0; i < total; i++)
    {
        Process.Start("calc.exe"); // anything in /system32 is already on the path
        Thread.Sleep(100); // 100 milliseconds
    }
