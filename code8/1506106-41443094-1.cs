        enter code here
       
    
     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace TestListInt
        {
            class Program
            {
                public class WrapperListInt
                {
                    public List<int> list;
                    public WrapperListInt(List<int> list)
                    {
                        this.list = list;
                    }
        
                    public override int GetHashCode()
                    {
                        return 0;
                    }
                    public override bool Equals(object obj)
                    {
                        if (this == obj) return true;
                        WrapperListInt o = obj as WrapperListInt;
                        if (this.list.Count != o.list.Count) return false;
        
                        for (int i = 0; i < this.list.Count; i++)
                        {
                            if (this.list[i] != o.list[i]) { return false; }
                        }
        
                        return true;
                    }
                }
                public Program() {
                    var testData = new List<List<int>>
                {
                     new List<int> { 1, 2, 3 },
                     new List<int> { 1, 3, 2 },
                     new List<int> { 1, 2, 3, 3 },
                     new List<int> { 6, 8, 3, 45,48 },
                     new List<int> { 9, 2, 15, 4 },
                     new List<int> { 9, 2, 4},
                     new List<int> { 9, 2, 4, 15 }
                };
        
                    //Order every list
                    foreach (var td in testData)
                    {
                        td.Sort();
                    }
    
        
                    Dictionary<WrapperListInt, int> dic = new Dictionary<WrapperListInt, int>();
                    foreach (var listInt in testData)
                    {
                        WrapperListInt aux = new WrapperListInt(listInt);
                        int countList;
                        if (dic.TryGetValue(aux, out countList))
                        {
                            dic[aux]++;
                        }
                        else
                        {
                            dic.Add(aux, 1);
                        }
                    }
        
                    foreach (var d in dic)
                    {
                        var setString = String.Join(", ", d.Key.list);
                        Console.WriteLine($" {d.Value} | {setString}");
                    }
                }
                static void Main(string[] args)
                {
                    new Program();
                }
            }
        }
