    public partial class Canvas 
        : UserControl
    {
        // Implementing custom double buffered graphics, since this is a lot
        // faster both when drawing and with respect to GC, since normal
        // double buffered graphics leaks disposable objects that the GC needs to finalize
        protected BufferedGraphicsContext m_bufferedGraphicsContext = 
            new BufferedGraphicsContext();
        protected BufferedGraphics m_bufferedGraphics = null;
        protected Rectangle m_currentClientRectangle = new Rectangle();
        public Canvas()
        {
            InitializeComponent();
            Setup();
        }
        private void Setup()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.Opaque | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = false;
            this.Dock = DockStyle.Fill;
        }
        private void DisposeManagedResources()
        {
            m_bufferedGraphicsContext.Dispose();
            if (m_bufferedGraphics != null)
            {
                m_bufferedGraphics.Dispose();
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Background paint is done in OnPaint
            // This reduces the "leaks" of System.Windows.Forms.Internal.DeviceContext 
            // and the amount of "GC" handles created considerably
            // as found by using CLR Profiler
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Specifically not calling base here since we draw entire area ourselves
            // base.OnPaint(e);
            // Should this be disposed? 
            using (e)
            using (var targetGraphics = e.Graphics)
            {
                ReallocBufferedGraphics(targetGraphics);
                // Use buffered graphics object
                var graphics = m_bufferedGraphics.Graphics;
                // Raise paint event
                PaintEvent?.Invoke(this.ClientRectangle, e.ClipRectangle, graphics);
                // Render to target graphics i.e. paint event args graphics
                m_bufferedGraphics.Render(targetGraphics);
            }
        }
        protected virtual void ReallocBufferedGraphics(Graphics graphics)
        {
            Rectangle newClientRectangle = this.ClientRectangle;
            // Realloc if new client rectangle is not contained within the current
            // or if no buffered graphics exists
            bool reallocBufferedGraphics = ShouldBufferBeReallocated(newClientRectangle);
            if (reallocBufferedGraphics)
            {
                if (m_bufferedGraphics != null)
                {
                    m_bufferedGraphics.Dispose();
                }
                m_bufferedGraphics = m_bufferedGraphicsContext.Allocate(
                     graphics, newClientRectangle);
                m_currentClientRectangle = newClientRectangle;
            }
        }
        protected virtual bool ShouldBufferBeReallocated(Rectangle newClientRectangle)
        {
            return !m_currentClientRectangle.Contains(newClientRectangle) || 
                    m_bufferedGraphics == null;
        }
        /// <summary>
        /// PaintEvent with <c>clientRectangle, clipRectangle, graphics</c> for the canvas.
        /// </summary>
        public event Action<Rectangle, Rectangle, Graphics> PaintEvent;
    }
