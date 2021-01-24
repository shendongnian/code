      static void Main(string[] args)
        {
            using (var src = new SqlConnection("server=.;database=tempdb;integrated security=true"))
            using (var dest = new SqlConnection("server=.;database=tempdb;integrated security=true"))
            {
                src.Open();
                dest.Open();
                var cmd = new SqlCommand("create table #t(id int)", dest);
                cmd.ExecuteNonQuery();
                bool cancel = false;
                var cancelationTokenSource = new CancellationTokenSource();
                var srcCmd = new SqlCommand("select row_number() over (order by (select null)) id from sys.objects o, sys.columns c, sys.columns c2", src);
                using (var rdr = srcCmd.ExecuteReader())
                {
                    var bc = new SqlBulkCopy(dest);
                    bc.NotifyAfter = 10000;
                    bc.SqlRowsCopied += (s, a) =>
                    {
                        Console.WriteLine($"{a.RowsCopied} rows copied");
                        if (cancel)
                        {
                            dest.Close();
                        }
                    };
                    bc.DestinationTableName = "#t";
                    bc.ColumnMappings.Add(new SqlBulkCopyColumnMapping("id", "id"));
                    var task = bc.WriteToServerAsync(rdr, cancelationTokenSource.Token);
                    Console.WriteLine("Hit any key to cancel the bulk load");
                    while (!task.Wait(1000))
                    {
                        if (Console.KeyAvailable)
                        {
                            cancelationTokenSource.Cancel();
                            try
                            {
                                task.Wait();
                            }
                            catch (AggregateException ex)
                            {
                                Console.WriteLine(ex.InnerException.Message);
                                Console.WriteLine("WriteToServer Canceled");
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Hit any key to exit");
                    return;
                }
            }
        }
