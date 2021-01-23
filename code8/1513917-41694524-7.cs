    void OnEnable ()
    {
    	onQuestionOptionClicked += OnQuestionOptionClicked;
    }
    
    void OnDisable ()
    {
    	onQuestionOptionClicked -= OnQuestionOptionClicked;
    }
    
    #region DELEGATE_EVENT_LISTENER
    void OnQuestionOptionClicked ()
    {
        GetComponent<Button>().interactable = false;
    	if (AnswerData.isCorrect){
    		GetComponent<Button>().image.color = Color.green;
    		Debug.Log("im true");
    	}
    }
    #endregion
