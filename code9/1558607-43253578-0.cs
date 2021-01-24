    string a ="12.22";
    int result;
    double result1;
    string ans = string.Empty;
    if(int.TryParse(a,out result))
    {
    ans = "Integer";
    }
    else if(double.TryParse(a,out  result1))
    {
    ans = "double";
    }
    else
    {
    ans = "string";
    }
