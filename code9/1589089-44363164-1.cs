    public GameObject textDisplayPrefab;
    public Transform rootTransform;
    
    public TextDisplay CreateNewTextDisplay(){
        GameObject newTextDisplayObject = Instanciate(textDisplayPrefab) as GameObject;
        newTextDisplayObject.transform.SetParent(rootTransform, false);
        TextDisplay newTextDisplay = newTextDisplayObject.GetComponent<TextDisplay>();
    return newTextDisplay;
    
    }
