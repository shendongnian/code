    foreach (RootObject c in Data)
    {
       debugOutput(c.dateNumeric.ToString());
       debugOutput(c.customerNumber.ToString());
       if(c.storedepartment != null)
       {
          foreach (Storedepartment sd in c.storedepartment)
          {
          debugOutput(sd.department.ToString());
          debugOutput(sd.descriptionOfDepartment.ToString());
          }
       }
       else
       {
          debugOutput("Storedepartment was null");
       }
    }
