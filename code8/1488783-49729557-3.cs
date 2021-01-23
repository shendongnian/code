            @helper GetHtml(List<MVCNestedGrid.Employee> employeeList, int parentID) {
            <table class="table table-bordered">
               @{
                   int currentID = 0;
                   int rowIndex = 0;
                   foreach (var i in employeeList.Where(a=>a.ReportsTo.Equals(parentID)))
                   {
                       if (i.EmployeeID == currentID)
                       {
                           continue;
                       }
                       else
                       {
                           if (rowIndex == 0)
                           {
                               <thead>
                                   <tr>
                                       <th>Employee ID</th>
                                       <th>Employee Name</th>
                                       <th>Title</th>
                                       <th>Home Phone</th>
                                   </tr>
                               </thead>
                           }
                           rowIndex++;
                           currentID = i.EmployeeID;
                           var Sub = employeeList.Where(a => a.ReportsTo.Equals(i.EmployeeID)).ToList();
                           var newEmployeeList = employeeList.Where(a => !a.EmployeeID.Equals(i.EmployeeID)).ToList();
                           <tbody>
                               <tr>
                                   <td>
                                       @if (Sub.Count > 0)
                                       {
                                           <span class="icon icon-e" style="float:left; cursor:pointer;"></span> 
                                       }
                                       else
                                       {
                                           <span style="display:inline-block;width:14px">&nbsp;</span>
                                       }
                                       @i.EmployeeID
                                   </td>
                                   <td>@i.TitleOfCourtesy @i.FirstName @i.LastName</td>
                                   <td>@i.Title</td>
                                   <td>@i.HomePhone</td>
                               </tr>
                               <tr style="display:none;">
                                   @if (Sub.Count > 0)
                                   {
                                       <td colspan="4" class="innerTable">
                                           @NestedData.GetHtml(newEmployeeList, i.EmployeeID)
                                       </td>
                                   }
                                   else
                                   {
                                        <td colspan="4">
         
                                        </td>
                                   }
                               </tr>
                           </tbody>
                       }
                   }
               }
            </table>
