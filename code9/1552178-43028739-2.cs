    namespace FbGeneratedKeys
    {
        class Program
        {
            private static SolutionType solutionType = SolutionType.FbScriptFB2_5;
    
            static void Main(string[] args)
            {
                var connectionString = new FbConnectionStringBuilder
                {
                    Database = @"D:\temp\generatedkey.fdb",
                    ServerType = FbServerType.Default,
                    UserID = "SYSDBA",
                    Password = "masterkey",
                }.ToString();
                FbConnection.CreateDatabase(connectionString, pageSize: 8192, overwrite : true);
    
                using (FbConnection connection = new FbConnection(connectionString))
                using (FbCommand cmd = new FbCommand())
                {
                    connection.Open();
    
                    cmd.Connection = connection;
                    switch (solutionType) {
                        case SolutionType.Firebird3:
                            Firebird3Example(cmd);
                            break;
                        case SolutionType.Firebird2_5:
                            Firebird2_5Example(cmd);
                            break;
                        case SolutionType.FbScriptFB2_5:
                            FbScriptFB2_5Example(cmd);
                            break;
                    }
    
                    cmd.CommandText = @"insert into withgeneratedid(column2) values (@column2) returning id";
                    cmd.Parameters.AddWithValue("@column2", "some value");
                    cmd.Parameters.Add(new FbParameter() { Direction = System.Data.ParameterDirection.Output });
                    cmd.ExecuteNonQuery();
    
                    Console.WriteLine("Id:" + cmd.Parameters[1].Value);
                    Console.ReadLine();
                }
            }
    
            private static void Firebird3Example(FbCommand cmd)
            {
                // Firebird 3 identity column
                cmd.CommandText = @"create table withgeneratedid(
        id integer generated by default as identity primary key, 
        column2 varchar(100)
    )";
                cmd.ExecuteNonQuery();
            }
    
            private static void Firebird2_5Example(FbCommand cmd)
            {
                // Firebird 2.5 and earlier normal primary key with trigger to generate key
                // Table
                cmd.CommandText = @"create table withgeneratedid(
        id integer primary key,
        column2 varchar(100)
    )";
                cmd.ExecuteNonQuery();
    
                // Sequence
                cmd.CommandText = "create sequence seq_withgeneratedid";
                cmd.ExecuteNonQuery();
    
                // Trigger
                cmd.CommandText = @"create trigger withgeneratedid_bi before insert on withgeneratedid
    as
    begin
        if (new.id is null) then new.id = next value for seq_withgeneratedid;
    end";
                cmd.ExecuteNonQuery();
            }
    
            private static void FbScriptFB2_5Example(FbCommand cmd)
            {
                string script = @"
    create table withgeneratedid(
        id integer primary key,
        column2 varchar(100)
    );
    
    create sequence seq_withgeneratedid;
    
    set term #;
    create trigger withgeneratedid_bi before insert on withgeneratedid
    as
    begin
        if (new.id is null) then new.id = next value for seq_withgeneratedid;
    end#
    set term ;#
    ";
                FbScript fbScript = new FbScript(script);
                fbScript.Parse();
                FbBatchExecution exec = new FbBatchExecution(cmd.Connection);
                exec.AppendSqlStatements(fbScript);
                exec.Execute();
            }
        }
    
        enum SolutionType
        {
            Firebird3,
            Firebird2_5,
            FbScriptFB2_5
        }
    }
