    public delegate void TaskDelegate();
    public class MissionGenerator
    {
        protected TaskDelegate MissionToInvoke;
        public MissionGenerator(IDelegateMission mission)
        {
            MissionToInvoke = mission.RaiseTask; 
        }
        public void StartMission() => MissionToInvoke();
    }
    public interface IDelegateMission
    {
        void RaiseTask();
    }
    public class Skarim : IDelegateMission
    {
        public void RaiseTask() => Debug.WriteLine("Yo.");
    }
    public class MainClass
    {
        private void MainMethod()
        {
             var sekerMission = new MissionGenerator(new Skarim());
             sekerMission.StartMission();
        }
    }
