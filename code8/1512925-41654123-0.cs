    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.AddMessageFilter(new TestMessageFilter());
            Application.Run(new Form1());
    
        }
    
    }
    
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class TestMessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            // Blocks all the messages relating to the left mouse button.
            if (m.Msg >= 513 && m.Msg <= 515)
            {
                // Execute some code here that you need before form is loaded
                return true;
            }
            return false;
        }
    }
