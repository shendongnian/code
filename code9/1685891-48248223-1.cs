    public partial class Form1 : Form
    { 
        public List<Character> charList = new List<Character>(); 
        public void SetData(string name)
        {
            Character c = new Character();
            c.Name = name;
            charList.Add(c);
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            UserInputForm uif = new UserInputForm(this);
            uif.Show();
        }  
    }
