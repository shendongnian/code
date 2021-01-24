    private class Strings
    {   
        public string A {get;set;}
        public string B {get;set;}
        public Strings(TextBox a, ComboBox b)
        {
           this.A = a.Name; this.B = b.SelectedValue.ToString();
        }
    }
