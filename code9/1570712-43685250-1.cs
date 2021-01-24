    public partial class Form1 : Form
    {
        //A list to hold all the ellipses to be drawn
        private List<Ellipse> ellipses = new List<Ellipse>();
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            //When the form is clicked, create a new ellipse and add it to the list.
            ellipses.Add(new Ellipse
            {
                Color = radioButton1.Checked ? Color.Red : (radioButton2.Checked ? Color.Yellow : Color.Blue),
                Location = e.Location,
                Size = new Size(50, 50),
                Filled = checkBox1.Checked
            });
            //Tell the form to redraw itself
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //Redraw each ellipse in the list.
            foreach (var ellipse in ellipses)
            {
                if (ellipse.Filled)
                {
                    //Use a using block to make sure the resource is disposed
                    using (var b = new SolidBrush(ellipse.Color))
                    {
                        e.Graphics.FillEllipse(b, new Rectangle(ellipse.Location, ellipse.Size));
                    }
                }
                else
                {
                    //Use a using block to make sure the resource is disposed
                    using (var p = new Pen(ellipse.Color))
                    {
                        e.Graphics.DrawEllipse(p, new Rectangle(ellipse.Location, ellipse.Size));                        
                    }
                }
            }
        }
    }
