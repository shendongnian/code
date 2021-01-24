    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                OpenForm("Form2");
            }
    
            public static void OpenForm(string FormName)
            {
                var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                    where t.Name.Equals(FormName)
                    select t.FullName).Single();
                var _form = (Form)Activator.CreateInstance(Type.GetType(_formName));
                if (_form != null)
                    _form.Show();
            }
        }
    }
