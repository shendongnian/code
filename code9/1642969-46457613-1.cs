    public partial class WebForm1 : System.Web.UI.Page
    {
        // Define Property and initialize List
        public List<Person> patients{ get; } = new List<Person>();
        public static void Page_Load(object sender, EventArgs e)
        {
        }
         public void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Use the Constructor with Parameters 
            Person p = new Person(TextBoxName.Text, TextBoxAge.Text, TextBoxPassword.Text);
            // Add your patient to your List
            patients.Add(p);
            // Use the ToString() of your Person
            ListBoxAll.Items.Add(p.ToString());
            
            if (p.Age > 18)
            {
                ListBoxAdults.Items.Add(p.ToString());    
            }                 
            else
            {    
                ListBoxKids.Items.Add(p.ToString());    
            }                        
        }    
    }
}
     
