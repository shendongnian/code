    public class InputForm: Form {
        public class TextBoxAttributes {
            public TextBoxAttributes() {
                this.ForeColor = DefaultForeColor;
                this.BackColor = DefaultBackColor;
                this.Font = DefaultFont;
            }
        
            public Color ForeColor {
                get; set;
            }
            
            public Color BackColor {
                get; set;
            }
            
            public Font Font {
                get; set;
            }
            
            public bool Bold {
                get {
                    return this.Font.Bold;
                }
                set {
                    var style = FontStyle.Regular;
                    
                    if ( value ) {
                        style = FontStyle.Bold;
                    }
                    
                    this.Font = new Font( this.Font, style );
                }
            }
            
            public bool Italic {
                get {
                    return this.Font.Bold;
                }
                set {
                    var style = FontStyle.Regular;
                    
                    if ( value ) {
                        style = FontStyle.Italic;
                    }
                    
                    this.Font = new Font( this.Font, style );
                }
            }
            
            public bool Underline {
                get {
                    return this.Font.Bold;
                }
                set {
                    var style = FontStyle.Regular;
                    
                    if ( value ) {
                        style = FontStyle.Underline;
                    }
                    
                    this.Font = new Font( this.Font, style );
                }
            }
            
            public float FontSize {
                get {
                    return this.Font.Size;
                }
                set {
                    this.Font = new Font( this.Font.FontFamily, value );
                }
            }
        }
    
        // ... more things...
        
        public TextBox AddTextBox(string label)
            => this.AddTextBox( label, new TextBoxAttributes() );
    
        public TextBox AddTextBox(string label, TextBoxAttributes attr)
        {
            var subPanel = new Panel { Dock = DockStyle.Top };
            var lblLabel = new Label { Text = label, Dock = DockStyle.Left };
            var tbEdit = new TextBox{
                Dock = DockStyle.Fill,
                ForeColor = attr.ForeColor,
                BackColor = attr.BackColor,
                Font = attr.Font
            };
    
            subPanel.Controls.Add( tbEdit );
            subPanel.Controls.Add( lblLabel );
            this.Panel.Controls.Add( subPanel );
    
            return tbEdit;
        }
    
        // ... more things...
    }
