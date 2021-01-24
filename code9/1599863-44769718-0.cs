    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace DirectAdmin
    {
        public class CustomTextBox : TextBox
        {
            private string _placeholder = "";
            public string Placeholder
            {
                get { return this._placeholder; }
                set {
                    this._placeholder = value;
                    this.Placeholder_Show(null, null);
                }
            }
            
            public CustomTextBox()
            {
                Initialize();
            }
            private void Initialize()
            {
                this.Enter += new EventHandler(this.Placeholder_Hide);
                this.Leave += new EventHandler(this.Placeholder_Show);
            }
            private void Placeholder_Hide(object sender, EventArgs e)
            {
                if (this.Text == this._placeholder)
                {
                    this.Text = "";
                    this.ForeColor = Color.Black;
                    this.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular);
                }
            }
            private void Placeholder_Show(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(this.Text))
                {
                    this.Text = this._placeholder;
                    this.ForeColor = Color.Gray;
                    this.Font = new Font("Segoe UI", 10.2F, FontStyle.Italic);
                }
            }
        }
    }
