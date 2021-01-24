       public partial class _Default : System.Web.UI.Page
       {
        protected void Page_Init(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => 
            key.Contains("txtDynamic")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.CreateTextBox("Dynamic" + i);
                i++;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnDefault_Click(object sender, EventArgs e)
        {
            int index = plc.Controls.OfType<TextBox>().ToList().Count + 1;
            this.CreateTextBox("Dynamic" + index);
            btnValue.Visible = true;
        }
        private void CreateTextBox(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = "txt" + id;
            plc.Controls.Add(txt);
            Button btn = new Button();
            btn.ID = "btn" + id;
            btn.Text = "Remove";
            btn.Click += new EventHandler(dynamicButton_Click);
            plc.Controls.Add(btn);
            Literal lt = new Literal();
            lt.Text = "<br />";
            plc.Controls.Add(lt);
        }
        protected void dynamicButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string id = button.ID;
            string controlID = id.Substring(10, id.Length - 10);
            Control ctlTextbox = plc.FindControl("txtDynamic" + controlID);
            plc.Controls.Remove(ctlTextbox);
            Control ctlButton = plc.FindControl("btnDynamic" + controlID);
            plc.Controls.Remove(ctlButton);
        }
        protected void btnValue_Click(object sender, EventArgs e)
        {
            string message = "";
            foreach (TextBox textBox in plc.Controls.OfType<TextBox>())
            {
                    message += textBox.ID + " : " + textBox.Text + "<br>";
            }
            lblMessage.Text = message;
        }
    }
