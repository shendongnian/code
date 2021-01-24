    // assume str contains the data with special chars
    char[] arr = str.ToCharArray();
    
    arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c) 
                                      || char.IsWhiteSpace(c) 
                                      || c == '-'
                                      || c == '_')));
    str = new string(arr);
