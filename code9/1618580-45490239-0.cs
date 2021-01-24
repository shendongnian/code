    public interface IWorker
    {
    }
    public class SettingsBase
    {
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class ExtendedSettingsA : SettingsBase
    {
        public string FilePath { get; set; }
    }
    public class ExtendedSettingsB : SettingsBase
    {
        public string SomeOtherProp { get; set; }
    }
    public class WorkerBase : IWorker
    {
        public SettingsBase Settings { get; set; }
    }
    public class WorkerExtendedA : IWorker
    {
        public ExtendedSettingsA Settings { get; set; }
    }
    public class WorkerExtendedB : IWorker
    {
        public ExtendedSettingsB Settings { get; set; }
    }
    public class XmlLoader
    {
        public IWorker Load(string xml)
        {
            return null; // instance of WorkerBase or WorkerExtendedA or WorkerExtendedB
        }
    }
    public class Consumer
    {
        public void Process(IWorker w)
        {
            if (w is WorkerBase)
            {
                WorkerBase wbase = w as WorkerBase;
                string name = wbase.Settings.Name;
                DateTime t = wbase.Settings.TimeStamp;
            }
            if (w is WorkerExtendedA)
            {
                WorkerExtendedA wa = w as WorkerExtendedA;
                string name = wa.Settings.Name;
                DateTime t = wa.Settings.TimeStamp;
                string f = wa.Settings.FilePath;
            }
            if (w is WorkerExtendedB)
            {
                WorkerExtendedB wb = w as WorkerExtendedB;
                string name = wb.Settings.Name;
                DateTime t = wb.Settings.TimeStamp;
                string other = wb.Settings.SomeOtherProp;
            }
        }
    }
