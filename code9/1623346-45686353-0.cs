     public Dictionary<string, int> agentStatisticsColumns = new Dictionary<string, int>();
        public static WsSupervisorService supervisorService = null;
        public static void Main(string[] args)
        {
            supervisorService = new WsSupervisorService();
            setSessionParameters sessionParams = new setSessionParameters();
            sessionParams.viewSettings = new viewSettings
            {
                appType = "Custom",
                forceLogoutSession = false,
                idleTimeOut = 600,
                rollingPeriod = rollingPeriod.Minutes5,
                shiftStart = 28800000,
                statisticsRange = statisticsRange.CurrentDay,
                timeZone = -25200000
            };
            getStatistics statistics = new getStatistics();
            statistics.statisticTypeSpecified = true;
            statistics.statisticType = statisticType.AgentStatistics;
            statistics.columnNames = null;
            try
            {
                getStatisticsResponse resp = supervisorService.getStatistics(statistics);
            }
            catch (Exception)
            {
                throw;
            }
        }
