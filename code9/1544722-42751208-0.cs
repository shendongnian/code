    void RestartGame(){
        //gets all elements of the parent 
        InputField [] childElements = letterPanel.GetComponentsInChildren<InputField> ();
        Debug.Log (childElements.Count());
        foreach (vInputField item in childElements) {
            if(item.name.Contains("InputField")){
                Destroy (item.gameObject);
            }
        }
        ShowInputField()
    }
