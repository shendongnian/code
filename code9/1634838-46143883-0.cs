    string input = Console.ReadLine();
    string result = "";
    string tmp = "";
    for(int i=input.Length-1; i>=0; i--)
    {
       if(input[i]==' ')
         {
             tmp = "";
             result = result + " " + tmp;
         }
       else
           tmp += input[i];
    }
     
