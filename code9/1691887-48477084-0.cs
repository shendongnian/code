    public class StyleManager
    {
    #region singleton
    public static StyleManager Instance { get; } = new StyleManager();
    private StyleManager()
    {
    }
    
    #endregion
    #region events
    public event EventHandler StyleChanged;
    private void OnStyleChanged()
    {
      this.StyleChanged?.Invoke(this, EventArgs.Empty);
    }
    #endregion
    #region properties
    public Color BackColor { get; set; }
    #endregion
    #region methods
    public void UpdateBackColor(Color color)
    {
      this.BackColor = color;
      this.OnStyleChanged();
    }
    #endregion
    }
