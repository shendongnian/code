    using System.Drawing;
    using System.Windows.Forms;
    
    namespace MyApplication
    {
        public static class ShowDialog
        {
            public static Color ForeColour { get; set; }
            public static Color BackColour { get; set; }
            public static Color ButtonBackColour { get; set; }
            public static Color ButtonForeColour { get; set; }
            public static FlatStyle ButtonFlatStyle { get; set; }
    
            public static bool ConfirmDialog(string message)
            {
                bool confirm = false;
                using (ConfirmDialog Dialog = new ConfirmDialog()
                {
                    Message = message,
                    ForeColor = this.ForeColour,
                    BackColor = this.BackColour,
                    ButtonBackColour = this.ButtonBackColour,
                    ButtonForeColour = this.ButtonForeColour,
                    ButtonFlatStyle = this.ButtonFlatStyle
                })
                {
                    DialogResult dr = Dialog.ShowDialog();
                    if (dr == DialogResult.Yes)
                    {
                        confirm = true;
                    }
                    else
                    {
                        confirm = false;
                    }
                }
                return confirm;
            }
        }
    }
