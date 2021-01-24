    public partial class Form2 : Form
    {
        public string ChosenItem;
        private void Form2_Load(object sender, EventArgs e)
        {
            ChosenItem = "Some default text";
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ChosenItem = listOfChoices.SelectedItems[0].SubItems[0].ToString();
            this.Close();
        }
        // Rest of form code omitted...
    }
