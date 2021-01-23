    private async Task<T> ExecuteDataUpload<T>(IEnumerable<object> data,PartitionKey partitionKey)
        {
            using (var client = new DocumentClient(m_endPointUrl, m_authKey, connPol))
                {
    
                    while (true)
                    {
                        try
                        {
                            var result = await client.ExecuteStoredProcedureAsync<T>(m_spSelfLink, new RequestOptions { PartitionKey = partitionKey }, data);
                            return result;
                        }
                        catch (DocumentClientException ex)
                        {
                            if (429 == (int)ex.StatusCode)
                            {
                                Thread.Sleep(ex.RetryAfter);
                                continue;
                            }
                            if (HttpStatusCode.RequestTimeout == ex.StatusCode)
                            {
                                Thread.Sleep(ex.RetryAfter);
                                continue;
                            }
                            throw ex;
                        }
                        catch (Exception)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                    }
                }
            }
    
    
    
     
    
    public async Task uploadData(IEnumerable<object> data, string partitionKey)
            {
                int groupSize = 600;
                int dataSize = data.Count();
                int chunkSize = dataSize > groupSize ? groupSize : dataSize;
                List<Task> uploadTasks = new List<Task>();
                while (dataSize > 0)
                {
                    IEnumerable<object> chunkData = data.Take(chunkSize);
                    object[] taskData = new object[3];
                    taskData[0] = chunkData;
                    taskData[1] = chunkSize;
                    taskData[2] = partitionKey;     
                    uploadTasks.Add(Task.Factory.StartNew(async (arg) =>
                    {
                        object[] reqdData = (object[])arg;
                        int chunkSizes = (int)reqdData[1];
                        IEnumerable<object> chunkDatas = (IEnumerable<object>)reqdData[0];
                        var partKey = new PartitionKey((string)reqdData[2]);
                        int chunkDatasCount = chunkDatas.Count();
                        while (chunkDatasCount > 0)
                        {
                            int insertedCount = await ExecuteDataUpload<int>(chunkDatas, partKey);
                            chunkDatas = chunkDatas.Skip(insertedCount);
                            chunkDatasCount = chunkDatasCount - insertedCount;
                        }
                    }, taskData));
                    data = data.Skip(chunkSize);
    
                    dataSize = dataSize - chunkSize;
                    chunkSize = dataSize > groupSize ? groupSize : dataSize;
                }
                await Task.WhenAll(uploadTasks);
            }
