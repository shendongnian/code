        public partial class Test: System.Web.UI.Page
        {
            var x,y;
            
            protected void Page_Load(object sender, EventArgs e)
            {           
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {            
                x = 2;
                y = 4;
            }
    
            protected void HiddenButton_Click(object sender, EventArgs e)
            {
            var z = x + y;
            }       
    
        }
