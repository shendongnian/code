    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication3
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                TestObject test1 = new TestObject()
                {
                    firstName = "Fred",
                    lastName = "Smith",
                    phone = "334-456-7698"
                };
                TestObject test2 = new TestObject()
                {
                    firstName = "Mary",
                    lastName = "Jones",
                    phone = "344-556-7558"
                };
                List<TestObject> list = new List<TestObject>();
                list.Add(test1);
                list.Add(test2);
    
                GridView1.DataSource = list;
                GridView1.DataBind();
               
            }
    
            protected void Button2_Click(object sender, EventArgs e)
            {
                //do nothing
            }
        }
    
        internal class TestObject
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phone { get; set; }
        }
    }
