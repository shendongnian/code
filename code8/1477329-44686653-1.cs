    function autoFillCustomer(){
            var roles = getAllUserRolesNames();
            var customerField = Xrm.Page.getAttribute("customer_field");
        
            for (var i = 0; i < roles.length; i++) {
                var roleName = roles[i];
        
                switch (roleName) {
                    case "Role Name 01":                
                        if ( customerField!= null )
                            customerFieldsetValue("hard-coded avlue 01");
                        
                        break;
                    
                    case "Role Name 021":                
                        if ( customerField!= null )
                            customerFieldsetValue("hard-coded avlue 02");
                        
                        break;
        
                    default;            
                        if ( customerField!= null )
                            customerFieldsetValue("default value if needed");
                }
            }
        }
