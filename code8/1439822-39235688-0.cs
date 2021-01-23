        foreach (IEnumerable<object> batch in objects.Batch(1000))
                {
                    var indexResponse = client.Bulk(s => s.IndexMany(batch,
                                             (bulkDescriptor, record) =>
                                               bulkDescriptor.Index("myindex").Parent(record.Id.ToString()).Document(record).Type("elasticchild").Id(record.Id.ToString())));
                    Console.WriteLine(indexResponse);
                }
