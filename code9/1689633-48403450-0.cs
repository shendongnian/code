    class ProcessResult
    {
        public int Count { get; set; }
        public double AverageDuration { get; set; }
        public string ProcessType { get; set; }
    }
    
    var result = (from p in ctx.ProcessTable
                  where p.ProcessInstanceID.Equals(processInstanceID)
                     && p.ProcessType.Equals(processType)
                     && p.ProcesoStatusEquals(ProcessStatusEnum.FINISHED)
                  group p by p.ProcessType into tp
                  select new ProcessResult
                  {
                      Count = tp.Count(),
                      AverageDuration = tp.Average(p => (p.EndDate - p.StartDate).TotalSeconds),
                      ProcessType = tp.Key
                  }).SingleOrDefault();
