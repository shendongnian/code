    public class MeTextBox
        : TextBox
    {
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if ( m_DependantControl != null )
                {
                    m_DependantControl.Enabled = !string.IsNullOrWhiteSpace(value);
                }
                base.Text = value;
            }
        }
    
        Control m_DependantControl;
    
        [Browsable(true)]
        public Control DependantControl
        {
            get { return m_DependantControl; }
            set { m_DependantControl = value; }
        }
    }
