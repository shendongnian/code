    private float finePrice = 0.0001f, valueEntered;
    public InputField enterValue;
    public Text estimatedValue;
    if(float.TryParse(enterValue.Text, out valueEntered))
    {
        estimatedValue.text = (finePrice * valueEntered).ToString();
    } 
    else
    {
        estimatedValue.text = "Please enter a float value";
    }
    
