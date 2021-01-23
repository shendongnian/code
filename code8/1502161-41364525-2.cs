        private void StartService()
        {
            try
            {
                InitializeLogger();
                m_logger.Information("Application started.");
                while (m_isRunning)
                {
                    RunProcess();
                }
            }
            catch (Exception ex)
            {
                if (m_logger != null)
                {
                    m_logger.Error(ex, "An exception has occurred in the StartService method call");
                }
                throw new Exception(ex.Message);
            }
        }
