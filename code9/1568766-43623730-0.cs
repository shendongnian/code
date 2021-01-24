    private void releaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
                var process = System.Diagnostics.Process.GetProcessesByName("Excel");
                foreach (var p in process)
                {
                    if (!string.IsNullOrEmpty(p.ProcessName))
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Excel Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
