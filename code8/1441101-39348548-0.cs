    private readonly Dictionary<string, DynoPanel> children;
    public Panel container;
    private List<Rectangle> startingRectangles;
    
    public DynoContainer(Control parent)
    {
    	children = new Dictionary<string, DynoPanel>();
    	container = new Panel
    	{
    		Dock = DockStyle.Fill
    	};
    	parent.Controls.Add(container);
        container.FindForm().ResizeBegin += OnResizeBegin;
    	container.Resize += ContainerOnResize;
    }
