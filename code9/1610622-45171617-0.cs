    public class CompanySettingView
    {
        public List<CompanySetting> Settings { get; set; }
        public CompanySetting NewSetting { get; set; }
        public CompanySettingView()
        {
            this.Settings = new List<CompanySetting>();
            this.NewSetting = new CompanySetting();
        }
    }
