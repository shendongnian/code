    public GameObject[] resultsItem;
    public GameObject gameObjectWithScriptResults; // Attach the gameobject with the script "AnswerButtonClicked"
    void OnEnable()
    {
       ShowResults();
    }
    void ShowResults(){
       for(int i = 0;i < gameObjectWithScriptResults.getComponent<Script>.results.Count;i++) //this results are from where you have the other script
       {
           //Draw your result[i]
           resultsItem[i].GetComponent<Text>().text = gameObjectWithScriptResults.getComponent<Script>.results[i];
       }
    }
