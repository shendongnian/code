        public static IList<JobExtended> SelectJobExtended(this IQueryable<Data.Job> query)
        {
            return query
                .Select(o => new JobExtended()
                {
                    JobId = job.jobId,
                    NodeId = job.nodeId,
                    ...
                }
        }
