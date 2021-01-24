    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    namespace WindowsFormsApp1
    {
        public partial class CheckComboBox : ComboBox
        {
            public event EventHandler CheckStateChanged;
            public CheckComboBox()
            {
                this.DrawMode = DrawMode.OwnerDrawFixed;
                this.DrawItem += new DrawItemEventHandler(CheckComboBox_DrawItem);
                this.SelectedIndexChanged += new EventHandler(CheckComboBox_SelectedIndexChanged);
            }
            void CheckComboBox_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (e.Index == -1)
                {
                    return;
                }
                if (!(Items[e.Index] is CheckComboBoxItem))
                {
                    e.Graphics.DrawString(
                    Items[e.Index].ToString(),
                    this.Font,
                    Brushes.Black,
                    new Point(e.Bounds.X, e.Bounds.Y));
                    return;
                }
                CheckComboBoxItem box = (CheckComboBoxItem)Items[e.Index];
                CheckBoxRenderer.RenderMatchingApplicationState = true;
                CheckBoxRenderer.DrawCheckBox(
                e.Graphics,
                new Point(e.Bounds.X, e.Bounds.Y),
                e.Bounds,
                box.Text,
                this.Font,
                (e.State & DrawItemState.Focus) == 0,
                box.CheckState ? CheckBoxState.CheckedNormal :
                    CheckBoxState.UncheckedNormal);
            }
            void CheckComboBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                CheckComboBoxItem item = (CheckComboBoxItem)SelectedItem;
                item.CheckState = !item.CheckState;
                CheckStateChanged?.Invoke(item, e);
            }
        }
    }
