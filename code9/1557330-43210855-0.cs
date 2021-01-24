        public bool UpdateCustomer(Customer customer, CustomerDto dto)
        {
            //Get properties from both objects
            System.Reflection.PropertyInfo[] customerProperties = customer.GetType().GetProperties();
            System.Reflection.PropertyInfo[] dtoProperties = dto.GetType().GetProperties();
            //Get properties that have the same name on both objects
            var propertiesToCompare = from customerProp in customerProperties 
                                      join dtoProp in dtoProperties 
                                      on customerProp.Name equals dtoProp.Name
                                      select customerProp;
            foreach (var property in propertiesToCompare)
            {
                if (property.GetValue(customer, null) != property.GetValue(dto, null))
                    return true;
            }
            return false;
        }
