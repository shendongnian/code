    public static IEnumerable<UserAssignmentDto> StaffAssignmentsUsingStoredProcedure(System.Data.DataTable dataTable)
    {
        var retList = List<UserAssignmentDto>();
    
        for(int i = 0; i < dataTable.Rows.Count; i++)
        {
              var row = dataTable.Rows[i];
              var temp = new UserAssignmentDto(){
                  Id = row["AssignmentNumber"],
                  Position = row["EsrPositionTitle"]
              };
    
              retList.Add(temp);     
        }
    
        return retList;
    }
