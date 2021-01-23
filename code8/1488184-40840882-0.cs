    public partial class Form1 : Form
    {
        protected EventHandler<PanelEventArg> OnSetPanelA = new EventHandler<PanelEventArg>((sender, e) => { }); //stub
        protected EventHandler<PanelEventArg> OnSetPanelB = new EventHandler<PanelEventArg>((sender, e) => { }); //stub
        protected List<PanelBase> panels;
        public Form1() : base()
        {
            panels = new List<PanelBase>
            {
                new PanelA(),
                new PanelB()
            };
            foreach (var panel in panels)
            {
                OnSetPanelA += panel.OnSetPanel;
                OnSetPanelB += panel.OnSetPanel;
                panel.OnSomeEvent += Form1_OnSomeEvent;
            }
            foreach (var panel in panels.OfType<PanelB>())
            {
                panel.OnChangePanelA += Form1_OnChangePanelA;
            }
            InitializeComponent();
        }
        protected void SetPanelA(int iNew)
        {
            foreach (var panel in panels.OfType<PanelA>())
            {
                panel.SetPanelA(iNew);
                OnSetPanelA(this, new PanelEventArg
                {
                    Panel = panel
                });
            }
        }
        protected void SetPanelB(string strNew)
        {
            foreach (var panel in panels.OfType<PanelB>())
            {
                panel.SetPanelB(strNew);
                OnSetPanelA(this, new PanelEventArg
                {
                    Panel = panel
                });
            }
        }
        protected void Form1_OnSomeEvent(object sender, EventArgs e)
        {
            // handles events raised by the panel.
        }
        protected void Form1_OnChangePanelA(object sender, int iNew)
        {
            SetPanelA(iNew);
        }
    }
