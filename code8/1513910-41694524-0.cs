    #region DELEGATES
    public delegate void OnQuestionOptionClicked ();
    public static event OnQuestionOptionClicked onQuestionOptionClicked;
    #endregion
    
    #region DELEGATE_CALLS
    private void RaiseOnQuestionOptionClicked ()
    {
    	if (onQuestionOptionClicked != null)
    		onQuestionOptionClicked ();
    }
    #endregion
