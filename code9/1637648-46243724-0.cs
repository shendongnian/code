            static void Main(string[] args)
            {
                List<Func<string, string>> methods = new List<Func< string, string>>(){
                    methodA, methodB, methodC, methodD
                };
                foreach (Func<string,string> method in methods)
                {
                    string result = method("a");
                   
                }
                
            }
            static string methodA(string a)
            {
                return a;
            }
            static string methodB(string b)
            {
                return b;
            }
            static string methodC(string c)
            {
                return c;
            }
            static string methodD(string d)
            {
                return d;
            }
