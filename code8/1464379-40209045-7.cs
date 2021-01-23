    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public partial class HostForm : Form
    {
        private Panel containerPanel;
        private TransparentPanel transparentPanel;
        private PropertyGrid propertyGrid;
        public HostForm()
        {
            this.transparentPanel = new TransparentPanel();
            this.containerPanel = new Panel();
            this.propertyGrid = new PropertyGrid();
            this.SuspendLayout();
            this.propertyGrid.Width = 200;
            this.propertyGrid.Dock = DockStyle.Right;
            this.transparentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transparentPanel.Name = "transparentPanel";
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Name = "containerPanel";
            this.ClientSize = new System.Drawing.Size(450, 210);
            this.Controls.Add(this.transparentPanel);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.containerPanel);
            this.Name = "HostForm";
            this.Text = "Host";
            this.Load += this.HostForm_Load;
            this.transparentPanel.MouseClick += this.transparentPanel_MouseClick;
            this.transparentPanel.Paint += this.transparentPanel_Paint;
            this.ResumeLayout(false);
        }
        private void HostForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = transparentPanel;
            /**************************************/
            /*Load the form which you want to edit*/
            /**************************************/   
            var f = new Form(); 
            f.Location = new Point(8, 8);
            f.TopLevel = false;
            this.containerPanel.Controls.Add(f);
            SelectedObject = f;
            f.Show();
        }
        Control selectedObject;
        Control SelectedObject
        {
            get { return selectedObject; }
            set
            {
                selectedObject = value;
                propertyGrid.SelectedObject = value;
                this.Refresh();
            }
        }
        void transparentPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Controls.Count == 0)
                return;
            SelectedObject = GetAllControls(this.containerPanel)
                .Where(x => x.Visible)
                .Where(x => x.Parent.RectangleToScreen(x.Bounds)
                    .Contains(this.transparentPanel.PointToScreen(e.Location)))
                .FirstOrDefault();
            this.Refresh();
        }
        void transparentPanel_Paint(object sender, PaintEventArgs e)
        {
            if (SelectedObject != null)
                DrawBorder(e.Graphics, this.transparentPanel.RectangleToClient(
                    SelectedObject.Parent.RectangleToScreen(SelectedObject.Bounds)));
        }
        private IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllControls(ctrl)).Concat(controls);
        }
        void DrawBorder(Graphics g, Rectangle r)
        {
            var d = 4;
            r.Inflate(d, d);
            ControlPaint.DrawBorder(g, r, Color.Black, ButtonBorderStyle.Dotted);
            var rectangles = new List<Rectangle>();
            var r1 = new Rectangle(r.Left - d, r.Top - d, 2 * d, 2 * d); rectangles.Add(r1);
            r1.Offset(r.Width / 2, 0); rectangles.Add(r1);
            r1.Offset(r.Width / 2, 0); rectangles.Add(r1);
            r1.Offset(0, r.Height / 2); rectangles.Add(r1);
            r1.Offset(0, r.Height / 2); rectangles.Add(r1);
            r1.Offset(-r.Width / 2, 0); rectangles.Add(r1);
            r1.Offset(-r.Width / 2, 0); rectangles.Add(r1);
            r1.Offset(0, -r.Height / 2); rectangles.Add(r1);
            g.FillRectangles(Brushes.White, rectangles.ToArray());
            g.DrawRectangles(Pens.Black, rectangles.ToArray());
        }
        protected override bool ProcessTabKey(bool forward)
        {
            return false;
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Refresh();
        }
    }
