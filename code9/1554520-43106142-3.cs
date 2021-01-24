    public partial class Form1 : Form
    {
        // 1. This class-level variable will hold our string
        public static string PrintMessage { get; private set; }
        // 2. Reference your strPrint variable for the MessageBox as you were before
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(PrintMessage);
        }
        // 3. This method will update our string with values from TextBoxes
        private void UpdateText()
        {
            PrintMessage = "Gross = " + txtGross.Text + "\n Fit = " + txtFit.Text +
                "\n Soc = " + txtSoc.Text + "\n Med = " + txtMed.Text +
                "\n Net = " + txtNet.Text;
        }
        // 4. Call our update method when the Form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateText();
        }
        // 5. This EventHandler just calls our update method
        private void CommonTextChangedEvent(object sender, EventArgs e)
        {
            UpdateText();
        }
        // I have a `button1` on my Form1, and clicking this button shows Form2
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }
