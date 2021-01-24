    Regex reg = new Regex("[*'\",_&#^@]");
    str1 = reg.Replace(str1, string.Empty);
    Regex reg1 = new Regex("[ ]");
    str1 = reg.Replace(str1, "-");
   
