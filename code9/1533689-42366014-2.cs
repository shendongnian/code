    public class MeButton
        : Button
    {
        List<TextBox> m_DependantOn = new List<Control>();
    
        [Browsable(true)]
        public List<TextBox> DependantOn
        {
            get { return m_DependantOn; }
            set { RemoveEvents(); m_DependantOn = value; AssignEvents(); }
        }
    
        void RemoveEvents()
        {
            foreach(TextBox ctrl in m_DependantOn)
                ctrl.TextChanged -= WhenTextChanged;
        }
    
        void AssignEvents()
        {
            foreach(TextBox.ctrl in m_DependantOn)
                ctrl.TextChanged += WhenTextChanged;
        }
    
        void WhenTextChanged(object sender, TextChangedEventArgs e)
        {
            this.Enabled = true;
        }
    }
