     public static bool TryKillProcessByMainWindowHwnd(int processID)
        {
            try
            {
                Process.GetProcessById((int)processID).CloseMainWindow();
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (Win32Exception)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            return true;
        }
