    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    namespace DemoApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                // We need to get all logic drives of the system on Forms load
                var localDrives = DriveInfo.GetDrives();
                int i = 0;
                foreach(DriveInfo localDrive in localDrives)
                {
                    // Create for each Drive the specific button
                    Button bt = new Button();
                    // Add specific text to button
                    bt.Text = localDrive.Name;
                    // Set button's width
                    bt.Width = 40;
                    // Set location
                    bt.Location =  new Point(10+40*i,10);
                    i++;
                    // Add event handler for click to open File Explorer for that drive
                    bt.Click += new EventHandler((obj, args) =>
                    {
                        // This will open File explorer to the given path
                        Process.Start(localDrive.RootDirectory.FullName);
                    });
                    // And finally add our button to the Form
                    this.Controls.Add(bt);
                }
            }
        }
    }
