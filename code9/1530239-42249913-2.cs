    Button _thisButton;
    Sprite  _normalSprite;
    Sprite _highlightSprite;
    
    protected override void DoStateTransition (SelectionState state, bool instant){
        switch (state) {
        case Selectable.SelectionState.Normal:
            _thisButton.GetComponent<Image>().sprite = _normalSprite;   
            Debug.Log("statenormalasd");
            break;
        case Selectable.SelectionState.Highlighted:
            _thisButton.GetComponent<Image>().sprite = _normalSprite;    
        }
