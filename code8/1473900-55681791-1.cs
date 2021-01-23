    // Convinient metod to decide OS. false => linux in this case.
    public static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    private static void AddZ3ToProcessPath()
    {
        // We store our OS-dependent Z3 DLLs in diffrent folders in our root.
        var solverZ3Path = IsWindows() ? "z3winx64_485" : "z3linuxx64_485";
        var z3X64BinariesPath = "";
        if (IsWindows())
        {
            z3X64BinariesPath = $"{solverZ3Path}"; // Windows friendly
        }
        else
        {
            z3X64BinariesPath =$"/{solverZ3Path}"; // Unix friendly
        }
        var path = Uri.UnescapeDataString(z3X64BinariesPath); // Escape chars
        var name = "PATH"; // Add dlls to this environment variable
        var target = EnvironmentVariableTarget.Process; // But only for this process and not entire machine or user
        Environment.SetEnvironmentVariable(name, path, target);
    }
