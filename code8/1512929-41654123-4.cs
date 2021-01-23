    [SecurityPermission(SecurityAction.LinkDemand, Flags = 
    SecurityPermissionFlag.UnmanagedCode)]
    public class TestMessageFilter : IMessageFilter
    {
        private Hashtable forms = new Hashtable();
        public bool PreFilterMessage(ref Message m)
        {
            Control c = Control.FromHandle(m.HWnd);
    
            var form = c as Form;
            if (form != null &&
                !this.forms.ContainsKey(form))
            {
                form.Load += Form_Load;
                form.Activated += Form_Activated;
                form.FormClosed += Form_FormClosed;
                this.forms.Add(form, form);
            }
    
            return false;
        }
    
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.forms.ContainsValue(sender))
            {
                var f = sender as Form;
                f.Activated -= Form_Activated;
                f.Load -= Form_Load;
                this.forms.Remove(sender);
            }
        }
    
        private void Form_Activated(object sender, EventArgs e)
        {
            MessageBox.Show("Form_Activated...");
        }
    
        private void Form_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form_Load...");
        }
    }
