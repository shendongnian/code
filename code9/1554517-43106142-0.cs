    public partial class Form1 : Form
    {
        // 1. This class-level variable will hold our string
        private string strPrint;
        // 2. Reference your strPrint variable for the MessageBox as you were before
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strPrint);
        }
        // 3. This method will update our string with values from TextBoxes
        private void UpdateText()
        {
            strPrint = "Gross = " + txtGross.Text + "\n Fit = " + txtFit.Text +
                "\n Soc = " + txtSoc.Text + "\n Med = " + txtMed.Text +
                "\n Net = " + txtNet.Text;
            // Update something on the form with new text
            label1.Text = strPrint;
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
