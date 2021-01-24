    public static class ServerExtensions
    {
        public IEnumerable<WorkerStatsDisplay> GetSortedWorkerStats(this Server server)
        {
            return server.WorkerStats.OrderBy(ws => ws.Client);
        }
    }
