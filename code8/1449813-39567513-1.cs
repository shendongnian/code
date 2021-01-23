    string userName = @"ABC/Domain-name\Pinto";
    string edit = userName.Replace('\\', '/');
    string[] split = edit.Split(new Char[] {'/'}); 
    string final = split[0] + split[2];
    Console.WriteLine(final);	
