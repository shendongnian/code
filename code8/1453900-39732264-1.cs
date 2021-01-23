    public class BaseFormsWrapper : UserControl
    {
        public Panel PanelBasePanel;
        private ElementHost _wpfHost;
        private IMessenger _messengerInstance;
    
        public BaseFormsWrapper()
        {
            InitializeComponent();
            MessengerInstance.Register<ThemeChangedMessage>(this, HandleThemeChanged);
        }
    
        private void HandleThemeChanged(ThemeChangedMessage obj)
        {
            var instance = Activator.CreateInstance(_wpfHost.Child.GetType());
            var oldView = _wpfHost.Child;
            _wpfHost.Child = (UIElement) instance;
    
            var view = oldView as ViewBase;
            var newView = instance as ViewBase;
    
            if ((view != null) && (newView != null))
            {
                newView.DataContext = view.DataContext;
            }
        }
    
        /// <summary>
        /// Gets or sets an instance of a <see cref="IMessenger" /> used to
        /// broadcast messages to other objects. If null, this class will
        /// attempt to broadcast using the Messenger's default instance.
        /// </summary>
        private IMessenger MessengerInstance
        {
            get
            {
                return _messengerInstance ?? Messenger.Default;
            }
            set
            {
                _messengerInstance = value;
            }
        }
    
        public UIElement HostedControl
        {
            get { return _wpfHost.Child; }
            set { _wpfHost.Child = value; }
        }
    
        private void InitializeComponent()
        {
            PanelBasePanel = new Panel();
            _wpfHost = new ElementHost();
            PanelBasePanel.SuspendLayout();
            SuspendLayout();
            // 
            // panelBasePanel
            // 
            PanelBasePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelBasePanel.Controls.Add(_wpfHost);
            PanelBasePanel.Dock = DockStyle.Fill;
            PanelBasePanel.Location = new Point(0, 0);
            PanelBasePanel.Margin = new Padding(0);
            PanelBasePanel.Name = "PanelBasePanel";
            PanelBasePanel.Size = new Size(1126, 388);
            PanelBasePanel.TabIndex = 0;
            // 
            // wpfHost
            // 
            _wpfHost.BackColor = SystemColors.ControlLightLight;
            _wpfHost.BackgroundImageLayout = ImageLayout.None;
            _wpfHost.Dock = DockStyle.Fill;
            _wpfHost.Location = new Point(0, 0);
            _wpfHost.Name = "_wpfHost";
            _wpfHost.Size = new Size(1126, 388);
            _wpfHost.TabIndex = 0;
            _wpfHost.Child = null;
            // 
            // BaseFormsWrapper
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoSize = true;
            Controls.Add(PanelBasePanel);
            Name = "BaseFormsWrapper";
            Size = new Size(1126, 388);
            PanelBasePanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
