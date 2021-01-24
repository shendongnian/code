    Scanner m_Scanner = new Scanner();
    public void Main()
    {
      m_Scanner.PropertyChanged += UpdateGUI;
      m_Scanner.GetInfo();
    }
    
    private void UpdateGUI(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "OS")
        txtOs.Text = m_Scanner.OS;
      else if (e.PropertyName == "Name")
        txtName.Text = m_Scanner.Name;
    }
