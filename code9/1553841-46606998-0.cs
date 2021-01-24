    List<Object> parameters = new List<object>(); // needed for new Action
    parameters = new List<object>
    {
        new Action(()=>parameters.Count.ToString()),
        (double) 3.14159,
        (int) 42,
        "M-String theory",
        new System.Text.StringBuilder("This is a stringBuilder"),
        null,
    };
    string parmStrings = string.Empty;
    int index = -1;
    foreach (object param in parameters)
    {
        index++;
        Type type = param?.GetType() ?? typeof(ArgumentNullException);
        switch ("")
        {
            case string anyName when type == typeof(Action):
                parmStrings = $"{parmStrings} {(param as Action).ToString()} ";
                break;
            case string egStringBuilder when type == typeof(System.Text.StringBuilder):
                parmStrings = $"{parmStrings} {(param as System.Text.StringBuilder)},";
                break;
            case string egInt when type == typeof(int):
                parmStrings = $"{parmStrings} {param.ToString()},";
                break;
            case string egDouble when type == typeof(double):
                parmStrings = $"{parmStrings} {param.ToString()},";
                break;
            case string egString when type == typeof(string):
                parmStrings = $"{parmStrings} {param},";
                break;
            case string egNull when type == typeof(ArgumentNullException):
                parmStrings  = $"{parmStrings} parameter[{index}] is null";
                break;
            default: throw new System.InvalidOperationException();
        };
    } 
