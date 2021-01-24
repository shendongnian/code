    public partial class Form1 : Form
    {
	String pathName;
        public Form1()
        {
            InitializeComponent();
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
		pathname = openFileDialog1.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(pathname))
                    {
                        string inputLine;
                        while ((inputLine = sr.ReadLine()) != null)
                        {
                            // some operations
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                }
            }
            // Enable "Save" Button
            saveToolStripMenuItem.Enabled = true;
            // currentOpenedFile.FileName = openFileDialog1.FileName
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
		pathname = saveFileDialog2.FileName;
                using (StreamWriter sw = new StreamWriter(pathname))
                {
                    // some operations
                }
            }
            // currentOpenedFile.FileName = saveFileDialog1.FileName
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // openFileDialog1.FileName should be replaced by currentOpenedFile.FileName
            using (StreamWriter sw = new StreamWriter(pathname))
            {
                // some operations
            }
        }
    }
}
