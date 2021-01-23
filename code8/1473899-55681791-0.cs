    public static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    private static void AddZ3ToProcessPath()
    {
        var solverZ3Path = IsWindows() ? "z3winx64_485" : "z3linuxx64_485";
        var z3X64BinariesPath = "";
        if (IsWindows())
        {
            z3X64BinariesPath = $"{solverZ3Path}"; // You set this.
        }
        else
        {
            z3X64BinariesPath =$"/{solverZ3Path}";
        }
        var path = Uri.UnescapeDataString(z3X64BinariesPath);
        var name = "PATH";
        var target = EnvironmentVariableTarget.Process;
        Environment.SetEnvironmentVariable(name, path, target);
    }
