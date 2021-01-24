    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    class RichTextBoxEx : RichTextBox {
        public RichTextBoxEx() {
            base.AutoSize = true;
            base.Multiline = false;
        }
        [DefaultValue(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize {
            get => base.AutoSize;
            set => base.AutoSize = value;
        }
        [DefaultValue(false)]
        public override bool Multiline {
            get => base.Multiline;
            set {
                base.Multiline = value;
                base.AutoSize = !base.Multiline;
            }
        }
    }
