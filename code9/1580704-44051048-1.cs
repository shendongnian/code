    int _x, _y = 6;
    
    //Parameter
    int _fieldIndex = 4;
    float floatVal = 2;
    string stringVal = "Hello";
    bool boolVal = false;
    GameObject gObjVal = null;
    
    void Start()
    {
        Hashtable hashtable = new Hashtable();
        hashtable.Add("x", _x);
        hashtable.Add("z", _y);
        hashtable.Add("time", 2.0f);
        hashtable.Add("easetype", iTween.EaseType.easeInExpo);
        hashtable.Add("oncomplete", "afterPlayerMove");
    
        //Create oncompleteparams hashtable
        Hashtable paramHashtable = new Hashtable();
        paramHashtable.Add("value1", _fieldIndex);
        paramHashtable.Add("value2", floatVal);
        paramHashtable.Add("value3", stringVal);
        paramHashtable.Add("value4", boolVal);
        paramHashtable.Add("value5", gObjVal);
    
        //Include the oncompleteparams parameter  to the hashtable
        hashtable.Add("oncompleteparams", paramHashtable);
        iTween.MoveTo(gameObject, hashtable);
    }
    
    public void afterPlayerMove(object cmpParams)
    {
        Hashtable hstbl = (Hashtable)cmpParams;
        Debug.Log("Your int value " + (int)hstbl["value1"]);
        Debug.Log("Your float value " + (float)hstbl["value2"]);
        Debug.Log("Your string value " + (string)hstbl["value3"]);
        Debug.Log("Your bool value " + (bool)hstbl["value4"]);
        Debug.Log("Your GameObject value " + (GameObject)hstbl["value5"]);
    }
