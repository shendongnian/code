    using System;
    using System.Windows.Forms;
    
    namespace SampleViewer
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                string imagePath = args[0];
    
                Form sampleForm = new Form();
                PictureBox pctBox = new PictureBox();
                pctBox.ImageLocation = imagePath;
                pctBox.Dock = DockStyle.Fill;
                sampleForm.Controls.Add(pctBox);
                sampleForm.ShowDialog();
    
                Console.ReadLine();
            }
        }
    }
