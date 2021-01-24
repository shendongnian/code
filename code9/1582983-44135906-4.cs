    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var location = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                List<ImageItem> imageItemsList = (
                    from file in Directory.GetFiles(location)
                    select new ImageItem
                    {
                            Name = Path.GetFileName(file),
                            Bytes = File.ReadAllBytes(file),
                            Description = "Inserted from code sample"
                        }
                    ).ToList();
    
                DatabaseImageOperations ops = new DatabaseImageOperations();
                ops.InsertImages(imageItemsList);
            }
        }
    }
