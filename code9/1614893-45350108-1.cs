    public virtual async Task<int?> GetJobRunIdAsync(int jobId)
    {
      var jobMonRequest = ...;
      var jobMonResponse = await Client.jobmonAsync(jobMonRequest);
      if (jobMonResponse == null)
        return null;
      if (jobMonResponse.jobrun.Length > 1)
        throw  new Exception("More than one job found, Wizards are abound.");
      return jobMonResponse.jobrun.Single().id;
    }
