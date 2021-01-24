        [DbContext(typeof(DataContext))]
        [Migration(nameof(DataContext) + nameof(GetDepartmentRowVersion))]
        public class GetDepartmentRowVersion : Migration
        {
            protected override void Up(MigrationBuilder builder)
            {
                var sp = $@"
    CREATE FUNCTION {nameof(DataContext.GetDepartmentRowVersion)} (@Id INT) RETURNS BINARY(8) AS BEGIN
    DECLARE @rowVersion AS BINARY(8)
    IF @Id = 0 SELECT @rowVersion = MAX([{nameof(Department.RowVersion)}]) FROM {nameof(DataContext.Department)} ELSE SELECT @rowVersion = [{nameof(Department.RowVersion)}] FROM {nameof(DataContext.Department)} WHERE {nameof(Department.Id)} = @Id
    RETURN @rowVersion
    END";
    
                if (builder.ActiveProvider.Split('.').Last() == StorageProvider.SqlServer.ToString()) builder.Sql(sp);
            }
    
            protected override void Down(MigrationBuilder builder)
            {
                var sp = $@"IF OBJECT_ID('{nameof(DataContext.GetDepartmentRowVersion)}') IS NOT NULL DROP FUNCTION {nameof(DataContext.GetDepartmentRowVersion)}";
    
                if (builder.ActiveProvider.Split('.').Last() == StorageProvider.SqlServer.ToString()) builder.Sql(sp);
            }
        }
