       ISession session = ...;
       session.EnableFilter("effectiveDate").SetParameter("asOfDate", DateTime.Today);
       var results = session.CreateQuery("from Employee as e where e.Salary > :targetSalary")
       .SetInt64("targetSalary", 1000000L)
       .List<Employee>();
