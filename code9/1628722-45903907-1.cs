    public static IEnumerable<UserAssignmentDto> StaffAssignmentsUsingStoredProcedure(System.Data.DataTable dataTable)
            {
                UserAssignmentDto ret = new UserAssignmentDto();
                foreach (DataRow row in dataTable)
                {
                    ret.Id = row["AssignmentNumber"];
                    ret.Position = row["EsrPositionTitle"];
                    yield return ret;
                }
            }
