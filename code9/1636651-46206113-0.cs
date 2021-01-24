    private string saveValueName = string.empty; //better practice
    public string GetText()
    {
        return saveValueName;
    }
    public void SetText(string output)
    {
       //save the incoming parameter to your private property:
       saveValueName = output //this really should be called input since you are passing it in as a parameter but no biggie
    
       //Not really sure what this function does?
        DynamicValuesManager.Instance.SaveValue(saveValueName, output, true);
    }
    //Sample code to retrieve the value passed in:
     tempVariable = yourClassName.GetText()
