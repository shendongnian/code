    public static string ToSentence(string input)
    {
       var list = new List<char>();
        for (var i = 0; i < input.ToCharArray().Length; i++)
        {
                if(input.IndexOf("IDE",i-1)==i){
                    list.AddRange(" IDE");
                    i+=2; 
                }
                else{
                    var c = input.ToCharArray()[i];
                    foreach (char c1 in i > 0 && char.IsUpper(c) ? new[] {' ', c} : new[] {c})
                    list.Add(c1);
                }
         }
        return new string(list.ToArray());
    }
