    string sql = "select 
        [FileName], [FilePath]
    from 
        dbo.[tb_CrawlData] cr
    where exists (select 1
                  from [tb_CrawlData] cd
                  where cd.Content like '%data%'
                    and cr.Content like '%' + cd.Content + '%')
    group by 
        cr.FileName, [FilePath]
    order by 
        count(*) desc, cr.FileName"
    string connectionString = "Server=.\PDATA_SQLEXPRESS;Database=;User Id=sa;Password=2BeChanged!;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(sql, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
    }
