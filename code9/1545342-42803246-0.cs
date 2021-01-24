    [Designer(typeof(BorderedGroupBoxDesigner))]
    [DefaultEvent("Load")]
    public sealed partial class BorderedGroupBox : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        internal readonly Panel BackgroundPanel;
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        internal readonly Label TitelLabel;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        internal new readonly ContainerControl Container;
        private VisualStyleRenderer _renderer;
        private int _contentPanelTop => TitleHeight + 2;
        private int _contentPanelLeft => 1;
        private int _contentPanelWidth => Size.Width - 2;
        private int _contentPanelHeight => Size.Height - TitleHeight;
        
        /// <summary>
        /// Initializes the Control.
        /// </summary>
        public BorderedGroupBox()
        {
            InitializeComponent();
            
            //Create TitleLabel
            if (TitelLabel == null)
                TitelLabel = new Label
                {
                    Location = new Point(1, 1),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleLeft
                };
            //Create BackgroundPanel
            if (BackgroundPanel == null)
                BackgroundPanel = new Panel
                {
                    Location = new Point(1, TitleHeight - 1)
                };
            //Create Container and add Panel
            if (Container == null)
                Container = new ContainerControl
                {
                    Dock = DockStyle.Fill,
                    Padding = new Padding(-1),
                    Controls = { TitelLabel, BackgroundPanel }
                };
            //Add container and it's content to this control
            Controls.Add(Container);
            //Set sizes of inner controls
            TitelLabel.Size = new Size(Size.Width - 2, 20);
            BackgroundPanel.Size = new Size(Size.Width - 2, Size.Height - TitleHeight - 3);
            //Set anchor of inner controls
            TitelLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackgroundPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //Value defaults
            BackgroundColor = SystemColors.Window;
            BorderColor = SystemColors.GradientActiveCaption;
            TitleBackColor = Color.FromKnownColor(KnownColor.DodgerBlue);
            TitleFont = new Font("Calibri", TitleHeight - 9, FontStyle.Bold);
            TitleFontColor = SystemColors.Window;
            AllowDrop = true;
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
        public Color BackgroundColor { get { return BackgroundPanel.BackColor; } set { BackgroundPanel.BackColor = value; } }
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
                BackgroundPanel.Location = new Point(BackgroundPanel.Location.X, value + 2);
                BackgroundPanel.Size = new Size(BackgroundPanel.Size.Width, Size.Height - value - 3);
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
        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.ControlAdded" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.ControlEventArgs" /> that contains the event data. </param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.BringToFront();
        }
    }
    internal class BorderedGroupBoxDesigner : ParentControlDesigner
    {
        internal static SelectionRulesEnum SelectionRule;
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            EnableDragDrop(true);
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
