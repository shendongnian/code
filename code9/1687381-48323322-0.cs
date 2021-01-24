    public class CustomRollingAppender : RollingFileAppender
    {
        DateTime next = DateTime.Today;
        public CustomRollingAppender()
        {
        }
        protected override void AdjustFileBeforeAppend()
        {
            string file = File;
            DateTime newDt = DateTime.Today;
            if (next < newDt)
            {
                next = newDt.AddDays(1);
                string rollDir = Path.Combine(Path.GetDirectoryName(file), DateTime.Today.ToString("yyyyMMdd"));
                Directory.CreateDirectory(rollDir);
                string toFile = Path.Combine(rollDir, String.Format("{0}_{1}", Path.GetFileName(file), DateTime.Today.ToString("yyyyMMdd")));
                this.CloseFile();
                RollFile(file, toFile);
                SafeOpenFile(File, false);
            }
            base.AdjustFileBeforeAppend();
        }
    }
