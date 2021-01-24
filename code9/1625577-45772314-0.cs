    public void ImportDataFromCloudStorage(BigQueryClient client, string uri, TableReference reference, WriteDisposition disposition = WriteDisposition.WriteIfEmpty)
        {
          BigQueryJob job = client.CreateLoadJob(uri, reference, null, new CreateLoadJobOptions()
          {
            FieldDelimiter = ";",
            SkipLeadingRows = 1,
            AllowQuotedNewlines = true,
            WriteDisposition = disposition
          });
    
          job.PollUntilCompleted();
        }
