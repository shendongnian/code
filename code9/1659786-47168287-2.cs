    public static class ServerExtensions
    {
        public static IEnumerable<WorkerStatsDisplay> GetSortedWorkerStats(this Server server)
        {
            return server.WorkerStats.OrderBy(ws => ws.Client);
        }
    }
