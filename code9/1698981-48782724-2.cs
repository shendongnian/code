    public class InputForm: Form {
            public InputForm()
            {
                this.Panel = new TableLayoutPanel{ Dock = DockStyle.Fill };            
                this.textBoxes = new List<TextBox>();
                this.Controls.Add( this.Panel );
            }
            
            public TextBox AddTextBox(string label)
            {
                var subPanel = new Panel { Dock = DockStyle.Top };
                var lblLabel = new Label { Text = label, Dock = DockStyle.Left };
                var tbEdit = new TextBox{ Dock = DockStyle.Fill };
                
                subPanel.Controls.Add( tbEdit );
                subPanel.Controls.Add( lblLabel );
                this.Panel.Controls.Add( subPanel );
                
                return tbEdit;
            }
            
            public TableLayoutPanel Panel {
                get; private set;
            }
            
            public TextBox[] TextBoxes {
                get {
                    return this.textBoxes.ToArray();
                }
            }
            
            private List<TextBox> textBoxes;
        }
