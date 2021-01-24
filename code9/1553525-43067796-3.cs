    using(Process p = new Process())
    {
        p.StartInfo = psi;
        p.EnableRaisingEvents = true;
        p.HasExited += OnProcessExited;
    }
