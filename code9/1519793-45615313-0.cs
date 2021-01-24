    public override IEnumerable<string> GetBrowsingHistoryUrls(FileInfo fileInfo)
            {
                var fileName = fileInfo.FullName;
                var results = new List<string>();
                try
                {
                    int pageSize;
                    Api.JetGetDatabaseFileInfo(fileName, out pageSize, JET_DbInfo.PageSize);
                    SystemParameters.DatabasePageSize = pageSize;
    
                    using (var instance = new Instance("Browsing History"))
                    {
                        var param = new InstanceParameters(instance);
                        param.Recovery = false;
                        instance.Init();
                        using (var session = new Session(instance))
                        {
                            Api.JetAttachDatabase(session, fileName, AttachDatabaseGrbit.ReadOnly);
                            JET_DBID dbid;
                            Api.JetOpenDatabase(session, fileName, null, out dbid, OpenDatabaseGrbit.ReadOnly);
    
                            using (var tableContainers = new Table(session, dbid, "Containers", OpenTableGrbit.ReadOnly))
                            {
                                IDictionary<string, JET_COLUMNID> containerColumns = Api.GetColumnDictionary(session, tableContainers);
    
                                if (Api.TryMoveFirst(session, tableContainers))
                                {
                                    do
                                    {
                                        var retrieveColumnAsInt32 = Api.RetrieveColumnAsInt32(session, tableContainers, columnIds["ContainerId"]);
                                        if (retrieveColumnAsInt32 != null)
                                        {
                                            var containerId = (int)retrieveColumnAsInt32;
                                            using (var table = new Table(session, dbid, "Container_" + containerId, OpenTableGrbit.ReadOnly))
                                            {
                                                var tableColumns = Api.GetColumnDictionary(session, table);
                                                if (Api.TryMoveFirst(session, table))
                                                {
                                                    do
                                                    {
    
                                                        var url = Api.RetrieveColumnAsString(
                                                            session,
                                                            table,
                                                            tableColumns["Url"],
                                                            Encoding.Unicode);
                                                        results.Add(url);
    
                                                    }
                                                    while (Api.TryMoveNext(session, table.JetTableid));
                                                }
                                            }
                                        }
                                    } while (Api.TryMoveNext(session, tableContainers));
                                }
                            }
                        }
                    }
    
                }
                catch (Exception ex)
                {
                    // log goes here....
                }
    
                return results;
            }
