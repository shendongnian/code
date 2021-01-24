     private void dgvEmployee_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_newRow)
            {
                EmployeeDataAccess empData = new EmployeeDataAccess();
                empData.InsertEmployee(
                                       dgvEmployee[1, e.RowIndex].Value.ToString(),
                                       dgvEmployee[2, e.RowIndex].Value.ToString(),
                                       dgvEmployee[3, e.RowIndex].Value.ToString(),
                                       Convert.ToInt32(dgvEmployee[4, e.RowIndex].Value)
                                       );
                dgvEmployee.BeginEdit(true);
                dgvEmployee.EndEdit();
                _newRow = false;
            }
            else
            {
                return;
            }
        }
    public void InsertEmployee(string initials, string firstName, string lastName, int active)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnection.NorthGA_WarpingTest))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertEmployee";
                    cmd.Parameters.AddWithValue("@Initials", initials);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = active;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    	@Initials varchar(3),
	    @FirstName varchar(25),
	    @LastName varchar(25),
	    @Active bit
    AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	
	INSERT INTO [Employee]
               ( 
			     [Initals],
			     [FName],
			     [LName],
			     [Active]         
                )
	 VALUES (
	          @Initials,
			  @FirstName,
			  @LastName,
			  @Active
			)
    END
