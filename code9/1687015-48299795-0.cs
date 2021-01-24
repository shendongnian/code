     private void debugOutput(string strDebugText)
            {
                try
                {
                    System.Diagnostics.Debug.Write(strDebugText);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.Write(ex.Message.ToString());
                }
            }
