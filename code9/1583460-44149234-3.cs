    public override string ToString()
    {
       StringBuilder t = new StringBuilder();
       foreach(Employee e in this.Employees)
       t.AppendLine (string.Format ("Employee: {0}",e.Fullname));
       return t.ToString ();
    }
