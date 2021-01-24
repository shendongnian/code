    public class CanvasDrawingObject : FrameworkElement
    {
        VisualCollection m_children;
		DrawingVisual m_drawingVisual;
        public CanvasDrawingObject( )
            : base( )
        {
            m_children = new VisualCollection(this);
            m_drawingVisual = new DrawingVisual();
            m_children.Add(m_drawingVisual);
        }
		
		public void PopulateMyContent( )
		{
            // place it somewhere
            Canvas.SetLeft(this, 7);
            Canvas.SetTop(this, 42);
            // draw
            DrawingContext context = this.DrawingVisual.RenderOpen();
            if (context != null)
            {
                // do your drawing
				//context.DrawLine(... );
                context.Close();
            }
		}
		
		protected override int VisualChildrenCount
		{
			get { return m_children.Count; }
		}
		protected override Visual GetVisualChild(int index)
		{
			if (index < 0 || index >= m_children.Count)
				throw new ArgumentOutOfRangeException();
			return m_children[index];
		}
	}
