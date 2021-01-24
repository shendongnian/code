    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ContextMenuStrip = new ContextMenuStrip();
            for (int i = 0; i < 100; i++)
                ContextMenuStrip.Items.Add($"Menu {i:00}"); // add some items;
            // remember the scroll position upon closing and restore it upon opening menu
            var point = Point.Empty;
            ContextMenuStrip.VisibleChanged += (s, e) =>
            {
                if (ContextMenuStrip.Visible)
                    ContextMenuStrip.AutoScrollOffset = point;
                else
                    point = ContextMenuStrip.AutoScrollOffset;
            };
        }
    }
