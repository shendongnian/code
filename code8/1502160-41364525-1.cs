        protected override void OnStop()
        {
            try
            {
                m_isRunning = false;
                m_logger.Information("Application stopped.");
                m_thread = null;
            }
            catch (Exception ex)
            {
                if (m_logger != null)
                {
                    m_logger.Error(ex, "An exception has occurred in the OnStop method call");
                }
                throw new Exception(ex.Message);
            }
        }
