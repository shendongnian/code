    string[] fileInput = File.ReadAllLines(path);
    
    string usernameString = fileInput[0].Split(": ")[1];
    string accessCodeString = fileInput[1].Split(": ")[1];
    string valueString = fileInput[2].Split(": ")[1];
    string emailString = fileInput[3].Split(": ")[1];
    int accessCode;    
    if (!int.TryParse(accessCodeString, out accessCode))
    {
         //Do something when accesscode is not int.
    }
    int value;    
    if (!int.TryParse(accessCodeString, out value))
    {
         //Do something when value is not int.
    }
    Console.WriteLine(accesscode);
    Console.WriteLine(emailString);
    Console.WriteLine(usernameString);
    Console.WriteLine(value);
