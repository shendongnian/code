        public partial class Form1 : Form
            {
                static List<UserData> savedData;
                public Form1()
                {
                    InitializeComponent();
                    savedData = new List<UserData>();
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
    //This is for example only, you get data then save it like this
                    savedData.Add(new UserData
                    {
                        Location = "US",
                        Name = "Boston"
                    });
                    savedData.Add(new UserData
                    {
                        Location = "US",
                        Name = "Texas"
                    });
        
                }
        
                private void button2_Click(object sender, EventArgs e)
                {
    //This is for example only, you WRITE your own business here
                    foreach (var item in savedData)
                    {
                        label1.Text = item.Location;
                        label2.Text = item.Name;
                    }
                }
            }
