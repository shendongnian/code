    Public overide string ToString()
    {
       StringBuilder t = new StringBuilder();
       foreach(Employee e in this.Employees)
    T.Add (e.ToString ());
       Return t.ToString ();
    }
