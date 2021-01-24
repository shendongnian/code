    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace SimpleTest
    {
    
        [ComVisible(true)]
        public interface ISimpleTestApp
        {
            void Show();
        }
    
        [ClassInterface(ClassInterfaceType.None)]
        public class SimpleTestApp : ISimpleTestApp
        {
            SimpleForm f;
    
            [STAThread]
            public void Show()
            {
                f = new SimpleForm();
                f.Show();
                f.FormClosed += F_FormClosed;
                MessageBox.Show("Done");
            }
    
            private void F_FormClosed(object sender, FormClosedEventArgs e)
            {
                f.Dispose();
            }
        }
    }
