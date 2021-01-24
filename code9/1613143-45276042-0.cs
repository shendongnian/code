    public class ExcelProcess
    {
        Process m_Process;
        public ExcelProcess(/* parameters of your choice */)
        {
            // instantiate process and assign it to the m_Process variable
        }
    
        public ExcelProcess(int id)
        {
            // this will instantiate process object and hook to the process with specified process id
            m_Process = Process.GetProcessById(id);
        }
    
        public void Close()
        {
            m_Process.Kill();
        }
    
        public override ToString()
        {
            // this will return process id as a string value
            return m_Process.Id.ToString();
        }
    }
