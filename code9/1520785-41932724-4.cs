     namespace WebApplication1
     {
     public partial class Default : System.Web.UI.Page
     {
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void submitEventMethod2(object sender, EventArgs e)
        {
            this.Mymethod();
        }
        public void mymethod1()
        {
          Myclass myClass=new Myclass ();
          myClass.mymethod2(TextBox1);
    
        }
        class Myclass
        {
         public void mymethod2(TextBox textBox)
         {
           textBox.Text = "some text";
         }
        }
    }
    }
