    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml.Linq;
    namespace WebApplication4
    {
        public partial class WebForm15 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsCallback)
                {
                    //credit to https://stackoverflow.com/questions/44076955/adding-additional-textboxes-to-aspx-based-on-xml#comment75336978_44078684
                    const string xml = @"<Number>
                           <Num>1</Num>
                           <Num>2</Num>
                           <Num>3</Num>
                         </Number>";
                    XDocument doc = XDocument.Parse(xml);
                    int i = 0;
                    foreach (XElement num in doc.Root.Elements())
                    {
                        TextBox box = new TextBox
                        {
                            ID = "dynamicTextBox" + i,
                            Text = num.Value,
                            ReadOnly = false
                        };
                        divToAddTo.Controls.Add(box);
                        divToAddTo.Controls.Add(new LiteralControl("<br/>"));
                        i++;
                    }
                }
            }
            protected void BtnGetValues_Click(object sender, EventArgs e)
            {
                IList<string> valueReturnArray = new List<string>();
                foreach (Control d in divToAddTo.Controls)
                {
                    if (d is TextBox)
                    {
                        valueReturnArray.Add(((TextBox)d).Text);
                    }
                }
                //valueReturnArray will now contain the values of all the textboxes
            }
        }
    }
