    string[] subNames = myWord.Split(' ');
    foreach (string name in subNames)
    {
        request=request.Where(contact =>
            contact.firstName.Contains(name) || 
            contact.lastName.Contains(name)
        );
    }
    var result = request.Any();
    
