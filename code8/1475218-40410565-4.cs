    static string getOskPath(string dir) {
        string path = Path.Combine(dir, "osk.exe");
        if (File.Exists(path)) {
            Process p = System.Diagnostics.Process.Start(path);
            if (p.IsWin64Emulator()) {
                path = string.Empty;
            }
            p.Kill();
            return path;
        }
        DirectoryInfo di = new DirectoryInfo(dir);
        foreach (DirectoryInfo subDir in di.GetDirectories().Reverse()) {
            path = getOskPath(Path.Combine(dir, subDir.Name));
            if (!string.IsNullOrWhiteSpace(path)) {
                return path;
            }
        }
        return string.Empty;
    }
