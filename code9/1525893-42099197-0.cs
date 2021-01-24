    using System;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void buttonOpen_Click(object sender, EventArgs e)
            {
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;
    
                    using (var reader = new StreamReader(dialog.OpenFile()))
                    {
                        // TODO read file
                    }
                }
            }
    
            private void buttonSave_Click(object sender, EventArgs e)
            {
                using (var dialog = new SaveFileDialog())
                {
                    if (dialog.ShowDialog() != DialogResult.OK)
                        return;
    
                    using (var writer = new StreamWriter(dialog.OpenFile()))
                    {
                        // TODO save file
                    }
                }
            }
        }
    }
