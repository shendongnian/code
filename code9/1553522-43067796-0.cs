    try {
        using (Process p = Process.Start(psi))
            p.WaitForExit();
    }
    catch (Exception ex) {
        MessageBox.Show(ex.Message);
    }
