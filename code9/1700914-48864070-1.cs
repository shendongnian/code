    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm2 : System.Web.UI.Page
        {
            protected void Page_PreInit(object sender, EventArgs e)
            {
                List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtDynamic")).ToList();
                int i = 1;
                foreach (string key in keys)
                {
                    this.CreateTextBox("txtDynamic" + i);
                    i++;
                }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void AddTextBox(object sender, EventArgs e)
            {
                int index = pnlTextBoxes.Controls.OfType<TextBox>().ToList().Count + 1;
                this.CreateTextBox("txtDynamic" + index);
            }
    
            private void CreateTextBox(string id)
            {
                TextBox txt = new TextBox();
                txt.ID = id;
                pnlTextBoxes.Controls.Add(txt);
    
                Literal lt = new Literal();
                lt.Text = "<br />";
                pnlTextBoxes.Controls.Add(lt);
            }
    
            protected void Download_Click(object sender, EventArgs e)
            { //???
                foreach (Control child in pnlTextBoxes.Controls)
                {
                    if (child.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")) //child is somehow never textbox
                    {
                        TextBox textBox = (TextBox)child;
                        System.Diagnostics.Debug.WriteLine(textBox.Text);
                    }
                }
            }
    
        }
    }
