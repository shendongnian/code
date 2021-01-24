            // use client
            try
            {
                ((IClientChannel)client).Close();
            }
            catch
            {
                ((IClientChannel)client).Abort();
            }
            finally
            {
                ((IDisposable)client).Dispose();
            }
