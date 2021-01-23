    public class LabeledComboBox : Control
    {
        static LabeledComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(typeof(LabeledComboBox)));
        }
    
        // define our own peer
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new LabeledComboBoxAutomationPeer(this);
        }
    
        protected class LabeledComboBoxAutomationPeer : FrameworkElementAutomationPeer
        {
            public LabeledComboBoxAutomationPeer(LabeledComboBox owner) : base(owner)
            {
            }
    
            // replace all TextBlockAutomationPeer by our custom peer for TextBlock
            protected override List<AutomationPeer> GetChildrenCore()
            {
                var list = base.GetChildrenCore();
                for (int i = 0; i < list.Count; i++)
                {
                    var tb = list[i] as TextBlockAutomationPeer;
                    if (tb != null)
                    {
                        list[i] = new InteractiveTextBlockAutomationPeer((TextBlock)tb.Owner);
                    }
                }
                return list;
            }
        }
    
        // just do the default stuff, instead of the strange TextBlockAutomationPeer implementation
        protected class InteractiveTextBlockAutomationPeer : FrameworkElementAutomationPeer
        {
            public InteractiveTextBlockAutomationPeer(TextBlock owner) : base(owner)
            {
            }
    
            protected override AutomationControlType GetAutomationControlTypeCore()
            {
                return AutomationControlType.Text;
            }
    
            protected override string GetClassNameCore()
            {
                return "TextBlock";
            }
        }
    }
