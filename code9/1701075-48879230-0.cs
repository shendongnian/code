    var operationTimedOutTasks = (from queue in context.TblRequestQueues
                                  where queue.MethodName == "ProcessCommand" 
                                      && !unwantedStatus.Contains(t.Status)
                                  let xml = XDocument.Parse(queue.Parameters)
                                  orderby queue.ID
                                  select new 
                                  {
                                    //Other columns
                                    Parameters = xml.Descendants("Root").FirstOrdDefault().Attribute("type").Value
                                  }).ToList();
