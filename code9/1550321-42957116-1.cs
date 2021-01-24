    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    [ProvideProperty("EnableDrag", typeof(Control))]
    public class DraggableExtender : Component, IExtenderProvider
    {
        private Dictionary<Control, bool> EnableDragValues = 
            new Dictionary<Control, bool>();
        public bool CanExtend(object extendee)
        {
            //You can limit the type of extendee here
            if (extendee is Control)
                return true;
            return false;
        }
        public bool GetEnableDrag(Control control)
        {
            if (EnableDragValues.ContainsKey(control))
                return EnableDragValues[control];
            return false;
        }
        public void SetEnableDrag(Control control, bool value)
        {
            EnableDragValues[control] = value;
            {
                if (value)
                {
                    control.MouseDown += MouseDown;
                    control.MouseMove += MouseMove;
                    control.Cursor = Cursors.SizeAll;
                }
                else
                {
                    control.MouseDown -= MouseDown;
                    control.MouseMove -= MouseMove;
                    control.Cursor = Cursors.Default;
                }
            }
        }
        Point p1;
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p1 = Cursor.Position;
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var control = (Control)sender;
                var p = control.Location;
                p.Offset(Cursor.Position.X - p1.X, Cursor.Position.Y - p1.Y);
                control.Location = p;
                p1 = Cursor.Position;
            }
        }
    }
