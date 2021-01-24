    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
        public partial class CheckComboBox : ComboBox
        {
            public CheckComboBox()
            {
                this.DrawMode = DrawMode.OwnerDrawFixed;
            }
        }
    }
