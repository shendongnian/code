    public partial class Form1 : Form
        {
            private string[] options;
    
            public Form1()
            {
                InitializeComponent();
                initTextBox();
            }
    
            private void initTextBox()
            {
    
                try
                {
                    options = File.ReadAllLines("input.txt");
                }
                catch (FileNotFoundException ex)
                {
                    File.CreateText("input.txt").Close();
    
                    options = File.ReadAllLines("input.txt");
                }
                if (options.Length == 0) return;
                foreach (var item in options)
                {
                    comboBox.Items.Add(item);
                }
            }
    
            private void button_addItem_Click(object sender, EventArgs e)
            {
                comboBox.Items.Add(textBox_newItem.Text);
                File.WriteAllLines("input.txt", options);
            }
        }
