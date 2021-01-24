        string[] lines = 
                {
                    "Var1 = [5,4,3,2]; Var2 = [2,8,6,Var1;4];",
                    "Var2 = [5,[4],2]Var1; Var2 = [2,8,6,Var1;4];"
                };
            Regex pattern = new Regex(@"^([^;]+);");
            foreach (string s in lines){
                Match match = pattern.Match(s);
                if (match.Success)
                {
                    Console.WriteLine(match.Value);
                }
            }
