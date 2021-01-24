    I have a web page called Default.aspx and a textbox called textBox1
    
    In the Default.aspx.cs, I can set the text by typing:
    
    TextBox1.text = "change text";
    Now I have created another class. How do I call textBox1 in this class? so I want to change the text for textBox1 in this class.
    
    So far i tried like this it is working fine in Mymethod but it is not working in Myclass.
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    using System.Drawing; 
     using System.Threading;
    
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
