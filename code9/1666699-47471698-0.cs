    sealed class ScanInput : IDisposable
    {
        public void Dispose()
        {
            m_Timer.Dispose();
        }
    }
