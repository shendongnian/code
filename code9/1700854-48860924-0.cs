     static void Main(string[] args)
                    {
                        List<FrmDBSet> response = new List<FrmDBSet>();
                        response.Add(new FrmDBSet() {Code ="A10", Month=9,Budget=100,Expense=10 });
                        response.Add(new FrmDBSet() { Code = "A10", Month = 10, Budget = 100, Expense = 40 });
                        response.Add(new FrmDBSet() { Code = "A10", Month = 11, Budget = 100, Expense = 40 });
                        response.Add(new FrmDBSet() { Code = "A10", Month = 12, Budget = 100, Expense = 10 });
            
                        var res = response.GroupBy(s => s.Budget).ToDictionary(s => s.Key, s => s.ToList()).ToList();
                        FinalCls finalvalue = new FinalCls();
            
                        foreach (var item in res)
                        {
                            finalvalue.Budget = item.Key;              
                            int index = 1;
                            foreach (FrmDBSet value in item.Value)
                            {
                                string propertyname = $"variable_month{index}";
                                PropertyInfo property = finalvalue.GetType().GetProperty(propertyname);
                                if(property!=null)
                                property.SetValue(finalvalue, value.Expense);
                                index++;
                            }
                        }
                        
                        Console.ReadKey();
                    }
    
    public class FinalCls
        {
            public int Budget { get; set; }
            public int variable_month1 { get; set; }
            public int variable_month2 { get; set; }
            public int variable_month3 { get; set; }
            public int variable_month4 { get; set; }
        }
    
    
        public class FrmDBSet
        {
            public string Code { get; set; }
            public int Month { get; set; }
            public int Budget { get; set; }
            public int Expense { get; set; }
        }
