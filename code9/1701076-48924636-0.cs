    var query = from queue in context.TblRequestQueues
                                                   where queue.MethodName == methodName
                                                   && queue.InterfaceName == interfaceName
                                                   && !unwantedStatus.Contains(queue.Status)
                                                   orderby queue.ID descending
                                                   select new
                                                   {
                                                       queue.QueuedTime,
                                                       queue.Parameters,
                                                       queue.Status,
                                                       queue.CurrentRetryCount,
                                                       queue.MaxRetryCount,
                                                       queue.RetryDelaySeconds,
                                                       queue.CompletedTime,
                                                       queue.LastTriedTime,
                                                       queue.LastError,
                                                       queue.PrincipalString
                                                   };
                    var operationTimedOutTasks = query.AsEnumerable()
                                                    .Select(t => new TblRequestQueueDto
                                                    {
                                                        QueuedTime = t.QueuedTime,
                                                        Parameters = t.Parameters,
                                                        CommandName = XDocument.Parse(t.Parameters).Element("Root").Descendants("Root").FirstOrDefault().Attribute("type").Value,
                                                        Status = t.Status,
                                                        CurrentRetryCount = t.CurrentRetryCount,
                                                        MaxRetryCount = t.MaxRetryCount,
                                                        RetryDelaySeconds = t.RetryDelaySeconds,
                                                        CompletedTime = t.CompletedTime,
                                                        LastTriedTime = t.LastTriedTime,
                                                        LastError = t.LastError,
                                                        PrincipalString = t.PrincipalString
                                                    }).ToList();
	
