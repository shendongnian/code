    public static IEnumerable<UserAssignmentDto> StaffAssignmentsUsingStoredProcedure(System.Data.DataTable dataTable)
    {
        var retList = List<UserAssignmentDto>();
    
        foreach (DataRow row in dataTable)
         {
              var temp = new UserAssignmentDto(){
                  Id = row["AssignmentNumber"],
                  Position = row["EsrPositionTitle"]
              };
    
              retList.Add(temp);     
         }
    
        return retList;
    }
