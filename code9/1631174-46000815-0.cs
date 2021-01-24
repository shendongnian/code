    public partial class _Default : Page
    {
        Dictionary<string, string> _dynamicControlId = new Dictionary<string, string>();
    
        protected void Page_Init(object sender, EventArgs e)
        {
            CreateControls();
        }
    
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ResultLabel.Text = "Result : " + RetrieveValues();
        }
    
        private void CreateControls()
        {
            string dynamicFieldstring = "one=1|two=2|three=3|four=4";
            if (!string.IsNullOrEmpty(dynamicFieldstring))
            {
                string[] groupControl = dynamicFieldstring.Split('|');
    
                for (int i = 0; i < groupControl.Length;)
                {
                    TableRow row = new TableRow();
    
                    for (int j = 0; j < 2; j++)
                    {
                        if (i >= groupControl.Length)
                            break;
    
                        string[] singleControl = groupControl[i].Split('=');
    
                        Label label = new Label();
                        TextBox textbox = new TextBox();
                        string textboxId = string.Empty;
                        string labelId = string.Empty;
                        TableCell cell = new TableCell();
    
                        label.Text = singleControl[0];
                        labelId = "lbl" + i + j;
                        label.ID = labelId; // <--- value should be labelId instead of textboxId
                        label.Attributes.Add("runat", "server");
                        cell.Controls.Add(label);
    
                        TableCell cell1 = new TableCell();
                        textbox.Text = singleControl[1];
                        textboxId = "txt" + i + j;
                        textbox.ID = textboxId;
                        textbox.Attributes.Add("runat", "server");
                        cell1.Controls.Add(textbox);
    
                        _dynamicControlId.Add(labelId, textboxId);
                        row.Cells.Add(cell);
                        row.Cells.Add(cell1);
                        i = i + 1;
                    }
                    extraAttr.Rows.Add(row);
                    Session["controllIds"] = _dynamicControlId;
                }
            }
        }
    
        private string RetrieveValues()
        {
            string value = string.Empty;
            _dynamicControlId = Session["controllIds"] as Dictionary<string, string>;
            if (_dynamicControlId != null && _dynamicControlId.Count > 0)
            {
    
                foreach (var item in _dynamicControlId)
                {
                    Label label = FindControlRecursive(extraAttr, item.Key) as Label;
                    value += label.Text + "="; // <--- Operator should be should be +=
                    var textbox = FindControlRecursive(extraAttr, item.Value) as TextBox;
                    value += textbox.Text + "|";
                }
            }
            return value;
        }
    
        private Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
                return root;
    
            return root.Controls.Cast<Control>()
                .Select(c => FindControlRecursive(c, id))
                .FirstOrDefault(c => c != null);
        }
    }
