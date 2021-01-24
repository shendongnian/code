    [Designer(typeof(BorderedGroupBoxDesigner))]
    public sealed partial class BorderedGroupBox : UserControl
    {
        /// <summary>The Panel which stores the content controls.</summary>
        [Category("Behavior")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public readonly Panel ContentPanel;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        internal readonly Label TitelLabel;
        private VisualStyleRenderer _renderer;
        private int _contentPanelTop => TitleHeight - 1;
        private int _contentPanelLeft => 1;
        private int _contentPanelWidth => Size.Width - 2;
        private int _contentPanelHeight => Size.Height - TitleHeight - 3;
        /// <summary>
        /// Initializes the Control.
        /// </summary>
        public BorderedGroupBox()
        {
            InitializeComponent();
            
            //Create TitleLabel
            TitelLabel = new Label
            {
                Location = new Point(1, 1),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft
            };
            //Create GroupingPanel
            ContentPanel = new Panel
            {
                Location = new Point(1, TitleHeight - 1)
            };
            
            //Create Container and add Panel
            Control container = new ContainerControl
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(-1),
                Controls = {TitelLabel, ContentPanel}
            };
            //Add container and it's content to this control
            Controls.Add(container);
            //Set sizes of inner controls
            TitelLabel.Size = new Size(Size.Width - 2, 20);
            ContentPanel.Size = new Size(Size.Width - 2, Size.Height - TitleHeight - 3);
            //Set anchor of inner controls
            TitelLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ContentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //Value defaults
            BackgroundColor = SystemColors.Window;
            BorderColor = SystemColors.GradientActiveCaption;
            TitleBackColor = Color.FromKnownColor(KnownColor.DodgerBlue);
            TitleFont = new Font("Calibri", TitleHeight - 9, FontStyle.Bold);
            TitleFontColor = SystemColors.Window;
            AllowDrop = true;
            //Set event handler
            ContentPanel.Resize += ContentPanelOnResize;
            ContentPanel.LocationChanged += ContentPanelOnLocationChanged;
        }
        private void ContentPanelOnLocationChanged(object sender, EventArgs eventArgs)
        {
            if (ContentPanel.Left != _contentPanelLeft | ContentPanel.Top != _contentPanelTop)
                ContentPanel.Location = new Point(_contentPanelLeft, _contentPanelTop);
        }
        private void ContentPanelOnResize(object sender, EventArgs eventArgs)
        {
            if (ContentPanel.Size.Width != _contentPanelWidth | ContentPanel.Size.Height != Size.Height - TitleHeight - 3)
                ContentPanel.Size = new Size(_contentPanelWidth, Size.Height - TitleHeight - 3);
        }
        //Make default property "BackColor" unvisible
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor { get; set; }
        //Use "BackgroundColor" instead of default "BackColor"
        /// <returns>The BackgroundColor associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("The backgroundcolor of the component.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Window")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BackgroundColor { get { return ContentPanel.BackColor; } set { ContentPanel.BackColor = value; } }
        /// <returns>The BorderColor associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the border color.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "GradientActiveCaption")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor { get { return BackColor; } set { BackColor = value; } }
        /// <returns>The BorderColor of the title associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the title color.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleBackColor { get { return TitelLabel.BackColor; } set { TitelLabel.BackColor = value; } }
        /// <returns>The height of the title associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the title height in px.")]
        [Category("Appearance")]
        [DefaultValue(typeof(int), "20")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TitleHeight
        {
            get { return TitelLabel.Size.Height; }
            set
            {
                TitelLabel.Size = new Size(TitelLabel.Size.Width, value);
                ContentPanel.Location = new Point(ContentPanel.Location.X, value + 2);
                ContentPanel.Size = new Size(ContentPanel.Size.Width, Size.Height - value - 3);
            }
        }
        /// <returns>The font of the title associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the title font.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Font), "Calibri; 11pt; style=Bold")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont { get { return TitelLabel.Font; } set { TitelLabel.Font = value; } }
        /// <returns>The ForeColor (color of the text) of the title associated with this control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the title font color.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Window")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleFontColor { get { return TitelLabel.ForeColor; } set { TitelLabel.ForeColor = value; } }
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the title text.")]
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text { get { return TitelLabel.Text; } set { TitelLabel.Text = value; } }
        
        /// <returns>Sets the interior spacing in the control.</returns>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [Description("Sets the interior spacing in the control.")]
        [Category("Layout")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new Padding Padding
        {
            get { return ContentPanel.Padding; }
            set { ContentPanel.Padding = value; }
        }
        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Focused || !Application.RenderWithVisualStyles) return;
            if (_renderer == null)
            {
                var elem = VisualStyleElement.Button.PushButton.Normal;
                _renderer = new VisualStyleRenderer(elem.ClassName, elem.Part, (int)PushButtonState.Normal);
            }
            var rc = _renderer.GetBackgroundContentRectangle(e.Graphics, new Rectangle(0, 0, Width, Height));
            rc.Height--;
            rc.Width--;
            using (var p = new Pen(Brushes.Purple))
            {
                e.Graphics.DrawRectangle(p, rc);
            }
        }
    }
    internal class BorderedGroupBoxDesigner : ControlDesigner
    {
        private BorderedGroupBox borderedGroupBox;
        internal static SelectionRulesEnum SelectionRule;
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            EnableDragDrop(true);
            
            borderedGroupBox = component as BorderedGroupBox;
            if (borderedGroupBox != null)
                EnableDesignMode(borderedGroupBox.ContentPanel, "Panel");
        }
        
        public override SelectionRules SelectionRules
        {
            get
            {
                switch (SelectionRule)
                {
                    case SelectionRulesEnum.All:
                        return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.AllSizeable;
                    case SelectionRulesEnum.UpDown:
                        return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.TopSizeable | SelectionRules.BottomSizeable;
                    case SelectionRulesEnum.RightLeft:
                        return SelectionRules.Visible | SelectionRules.Moveable | SelectionRules.LeftSizeable | SelectionRules.RightSizeable;
                    case SelectionRulesEnum.None:
                        return SelectionRules.Visible | SelectionRules.Moveable;
                    default:
                        return SelectionRules.Visible | SelectionRules.Moveable;
                }
            }
        }
        
        internal enum SelectionRulesEnum
        {
            All,
            UpDown,
            RightLeft,
            None
        }
    }
