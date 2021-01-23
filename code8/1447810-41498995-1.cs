    DevExpress.DataAccess.Sql.SqlDataSource datasource=(DevExpress.DataAccess.Sql.SqlDataSource)report.DataSource;
    if (datasource.Queries[0] is DevExpress.DataAccess.Sql.TableQuery)
        sqlQuery = (datasource.Queries[0] as DevExpress.DataAccess.Sql.TableQuery).GetSql(datasource.Connection.GetDBSchema());
    else
    {
        DevExpress.DataAccess.Sql.CustomSqlQuery sq = (DevExpress.DataAccess.Sql.CustomSqlQuery)sqd.Queries[0];
        sqlQuery = datasource.Sql;
    }
    query = sqlQuery.Replace("'\'", "''");
