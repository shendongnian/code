    public class SuggestComboBox : ComboBox
    {
      #region fields and properties
 
    private readonly ListBox _suggLb = new ListBox { Visible = false, TabStop = false };
    private readonly BindingList<string> _suggBindingList = new BindingList<string>();
    private Expression<Func<ObjectCollection, IEnumerable<string>>> _propertySelector;
    private Func<ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
    private Expression<Func<string, string, bool>> _filterRule;
    private Func<string, bool> _filterRuleCompiled;
    private Expression<Func<string, string>> _suggestListOrderRule;
    private Func<string, string> _suggestListOrderRuleCompiled;
 
    public int SuggestBoxHeight
    {
        get { return _suggLb.Height; }
        set { if (value > 0) _suggLb.Height = value; }
    }
    /// <summary>
    /// If the item-type of the ComboBox is not string,
    /// you can set here which property should be used
    /// </summary>
    public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
    {
    	get { return _propertySelector; }
	set
	{
	    if (value == null) return;
	    _propertySelector = value;
	    _propertySelectorCompiled = value.Compile();
	}
    }
 
    ///<summary>
    /// Lambda-Expression to determine the suggested items
    /// (as Expression here because simple lamda (func) is not serializable)
    /// <para>default: case-insensitive contains search</para>
    /// <para>1st string: list item</para>
    /// <para>2nd string: typed text</para>
    ///</summary>
    public Expression<Func<string, string, bool>> FilterRule
    {
        get { return _filterRule; }
        set
        {
            if (value == null) return;
            _filterRule = value;
            _filterRuleCompiled = item => value.Compile()(item, Text);
        }
    }
 
    ///<summary>
    /// Lambda-Expression to order the suggested items
    /// (as Expression here because simple lamda (func) is not serializable)
    /// <para>default: alphabetic ordering</para>
    ///</summary>
    public Expression<Func<string, string>> SuggestListOrderRule
    {
        get { return _suggestListOrderRule; }
        set
        {
            if (value == null) return;
            _suggestListOrderRule = value;
            _suggestListOrderRuleCompiled = value.Compile();
        }
    }
 
    #endregion
 
    /// <summary>
    /// ctor
    /// </summary>
    public SuggestComboBox()
    {
        // set the standard rules:
        _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
        _suggestListOrderRuleCompiled = s => s;
        _propertySelectorCompiled = collection => collection.Cast<string>();
 
        _suggLb.DataSource = _suggBindingList;
        _suggLb.Click += SuggLbOnClick;
 
        ParentChanged += OnParentChanged;
    }
 
    /// <summary>
    /// the magic happens here ;-)
    /// </summary>
    /// <param name="e"></param>
    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
 
        if (!Focused) return;
 
        _suggBindingList.Clear();
        _suggBindingList.RaiseListChangedEvents = false;
        _propertySelectorCompiled(Items)
             .Where(_filterRuleCompiled)
             .OrderBy(_suggestListOrderRuleCompiled)
             .ToList()
             .ForEach(_suggBindingList.Add);
        _suggBindingList.RaiseListChangedEvents = true;
        _suggBindingList.ResetBindings();
        
        _suggLb.Visible = _suggBindingList.Any(); 
        
        if (_suggBindingList.Count == 1 &&  
                    _suggBindingList.Single().Length == Text.Trim().Length)
        {
            Text = _suggBindingList.Single();
            Select(0, Text.Length);
            _suggLb.Visible = false;
        }
    }
 
    /// <summary>
    /// suggest-ListBox is added to parent control
    /// (in ctor parent isn't already assigned)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnParentChanged(object sender, EventArgs e)
    {
        Parent.Controls.Add(_suggLb);
        Parent.Controls.SetChildIndex(_suggLb, 0);
        _suggLb.Top = Top + Height - 3;
        _suggLb.Left = Left + 3;
        _suggLb.Width = Width - 20;
        _suggLb.Font = new Font("Segoe UI", 9);
    }
 
    protected override void OnLostFocus(EventArgs e)
    {
        // _suggLb can only getting focused by clicking (because TabStop is off)
        // --> click-eventhandler 'SuggLbOnClick' is called
        if (!_suggLb.Focused)
            HideSuggBox();
        base.OnLostFocus(e);
    }
    protected override void OnLocationChanged(EventArgs e)
    {
	base.OnLocationChanged(e);
	_suggLb.Top = Top + Height - 3;
	_suggLb.Left = Left + 3;
    }
    protected override void OnSizeChanged(EventArgs e)
    {
	base.OnSizeChanged(e);
	_suggLb.Width = Width - 20;
    }
 
    private void SuggLbOnClick(object sender, EventArgs eventArgs)
    {
        Text = _suggLb.Text;
        Focus();
    }
 
    private void HideSuggBox()
    {
        _suggLb.Visible = false;
    }
 
    protected override void OnDropDown(EventArgs e)
    {
        HideSuggBox();
        base.OnDropDown(e);
    }
 
    #region keystroke events
 
    /// <summary>
    /// if the suggest-ListBox is visible some keystrokes
    /// should behave in a custom way
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
    {
        if (!_suggLb.Visible)
        {
            base.OnPreviewKeyDown(e);
            return;
        }
 
        switch (e.KeyCode)
        {
            case Keys.Down:
                if (_suggLb.SelectedIndex < _suggBindingList.Count - 1)
                    _suggLb.SelectedIndex++;
                return;
            case Keys.Up:
                if (_suggLb.SelectedIndex > 0)
                    _suggLb.SelectedIndex--;
                return;
            case Keys.Enter:
                Text = _suggLb.Text;
	        Select(0, Text.Length);
	        _suggLb.Visible = false;
                return;
            case Keys.Escape:
                HideSuggBox();
                return;
        }
 
        base.OnPreviewKeyDown(e);
    }
 
    private static readonly Keys[] KeysToHandle  = new[] 
                { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        // the keysstrokes of our interest should not be processed be base class:
        if (_suggLb.Visible && KeysToHandle.Contains(keyData))
            return true;
        return base.ProcessCmdKey(ref msg, keyData);
    }
 
    #endregion
