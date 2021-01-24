    public static class Helpers
    {
                                                // note the "this"
        public static IQueryable<Job> PublicJobs(this IQueryable<Job> jobs)
        {
            return jobs.Where(j => !j.IsDeleted && !j.IsPrivate);
        }
    }
