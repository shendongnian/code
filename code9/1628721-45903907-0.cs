    public static IEnumerable<UserAssignmentDto> StaffAssignmentsUsingStoredProcedure(System.Data.DataTable dataTable)
            {
                foreach (DataRow row in dataTable)
                {
                   yield return new UserAssignmentDto()
                    {
                        Id = row["AssignmentNumber"],
                        Position = row["EsrPositionTitle"]
                    };               
                }
            }
