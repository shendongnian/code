    GameObject lastInput = null;
    
    void DeActivateLastInput()
    {
        if (lastInput != null)
        {
            InputField inputField = lastInput.GetComponent<InputField>();
            inputField.interactable = false;
            inputField.readOnly = true;
        }
    }
    
    //show next input field to enter letter
    private void ShowInputField()
    {
        GameObject inputFieldGameObject = inputFieldObjectPool.GetObject();
        //Reset this pool since it may have been disabled before from the DeActivateLastInput function
        InputField inputField = inputFieldGameObject.GetComponent<InputField>();
        inputField.interactable = true;
        inputField.readOnly = false;
    
        //Make this Input Last Input
        lastInput = inputFieldGameObject;
    
        inputFieldGameObject.transform.SetParent(inputFieldParent);
        Canvas.ForceUpdateCanvases();
        GameObject.Find("ScrollView").GetComponent<ScrollRect>().horizontalNormalizedPosition = 1;
    }
    
    public void DoneButton()
    {
        NextPlayerTurn();
        DeActivateLastInput();
        ShowInputField();
    }
