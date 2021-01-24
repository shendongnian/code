    public class MyClass
    {
        private string LoadedText;
    
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog2.FileName;
                try
                {
                    LoadedText = File.ReadAllText(file);
                }
                catch (IOException)
                {
                    //TODO: error handling
                }
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            // use `LoadedText`
            //Search from selected .txt file like: ("a"), ("b"), ("c")
        }
    }
