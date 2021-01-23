    private List<MyClass> backing;
    private BindingList<MyClass> bl;
    
        private void InitializeBindingList()
            {
                backing = new List<MyClass>();
                bl = new BindingList<MyClass>(backing);
                bl.Add(new MyClass("a", 32));
                bl.Add(new MyClass("b", 23));
                bl.Add(new MyClass("c", 11));
                bl.Add(new MyClass("d", 34));
                bl.Add(new MyClass("e", 53));
            }
        
        private void SortBindingList()
            {
                backing.Sort((MyClass X, MyClass Y) => X.Num.CompareTo(Y.Num));
                // tell the bindinglist to raise a list change event so that 
                // bound controls reflect the new item order
                bl.ResetBindings();
            }
        }
