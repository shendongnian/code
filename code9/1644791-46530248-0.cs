    List<Person> persons;
     protected void Page_Load(object sender, EventArgs e){
      if(!IsPostBack){
         List<Person> persons= new List<Person>();
         Session["personslist"]=persons;
      }else{
         persons= (List<Person>)Session["personslist"];
      }
    }
     
    protected void Button1_Click(object sender, EventArgs e){
     persons.Add(new 
     Person(TextBox1.Text,int.parse(TextBox2.Text),TextBox3.Text));
    }
