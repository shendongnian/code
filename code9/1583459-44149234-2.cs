    Public overide string ToString()
    {
       StringBuilder t = new StringBuilder();
       foreach(Employee e in this.Employees)
    T.AppendLine (string.Format ("Employee: {0}",e.Fullname));
       return t.ToString ();
    }
