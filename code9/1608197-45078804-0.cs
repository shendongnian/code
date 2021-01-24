    public DateTime EmployeeJoiningDate { get; set; }
    
    [NotMapped]
    public string EmpJd
    {
      get { return EmployeeJoiningDate.ToString(); } // Optionally add format string.
      set 
      {
        DateTime result;
        if (!DateTime.TryParse(value, out result))
          throw new ArgumentException("The provided EmpJd was not recognized as a date.");
        EmployeeJoiningDate = result;
      }
    }
