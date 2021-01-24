    Customer customer; // assume its initialized
    CustomerDto custDTO; 
    var recordsAreDifferent = false;
    foreach (var prop in custDTO.GetType().GetProperties())
    {
      PropertyInfo customerProperty = customer.GetType().GetProperty(prop.name);
      if(customerProperty == null) {continue;}
     if(!prop.GetValue(custDTO, null).Equals(customerProperty.GetValue(customer,    null)) {
         recordsAreDifferent = true;
      }
    }
