    public static readonly DependencyProperty HistoryProperty = DependencyProperty.Register("History", typeof(IEnumerable<UndoableCommand>), typeof(CodeTextboxHost), new FrameworkPropertyMetadata(new ObservableCollection<UndoableCommand>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(
    	(d, e) =>
    	{
    		var textBoxHost = d as CodeTextboxHost;
    		if (textBoxHost != null && textBoxHost._innerTextbox != null)
    		{
    			var history = textBoxHost.GetValue(e.Property) as ObservableCollection<UndoableCommand>;
    			if (history != null)
    			{
    				textBoxHost._innerTextbox.TextSource.Manager.History = history.ToLimitedStack(200);
    				textBoxHost._innerTextbox.OnUndoRedoStateChanged();
    			}
    			else
    			{
    				textBoxHost._innerTextbox.ClearUndo();
    			}
    		}
    	}), null));
    
    public static readonly DependencyProperty RedoStackProperty = DependencyProperty.Register("RedoStack", typeof(IEnumerable<UndoableCommand>), typeof(CodeTextboxHost), new FrameworkPropertyMetadata(new ObservableCollection<UndoableCommand>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(
    	(d, e) =>
    	{
    		var textBoxHost = d as CodeTextboxHost;
    		if (textBoxHost != null && textBoxHost._innerTextbox != null)
    		{
    			var redoStack = textBoxHost.GetValue(e.Property) as ObservableCollection<UndoableCommand>;
    			if (redoStack != null)
    			{
    				textBoxHost._innerTextbox.TextSource.Manager.RedoStack = redoStack.ToStack();
    				textBoxHost._innerTextbox.OnUndoRedoStateChanged();
    			}
    			else
    			{
    				textBoxHost._innerTextbox.ClearUndo();
    			}
    		}
    	}), null));
    
    public ObservableCollection<UndoableCommand> History
    {
    	get { return (ObservableCollection<UndoableCommand>) GetValue(HistoryProperty);}
    	set { SetCurrentValue(HistoryProperty, new ObservableCollection<UndoableCommand>(value));}
    }
    
    public ObservableCollection<UndoableCommand> RedoStack
    {
    	get { return (ObservableCollection<UndoableCommand>) GetValue(RedoStackProperty); }
    	set { SetCurrentValue(RedoStackProperty, new ObservableCollection<UndoableCommand>(value));}
    }
