    public enum ReportType
        {
            Application = 1,
            Feelings,
            AppVsEmotion,
            Help
        }
        [Serializable]
        public class StandardInfoForm
        {
            public bool AskToChooseReport = true;
            [Prompt("What kind of report you would like? {||}")]
            public ReportType? Report { get; set; }
            [Prompt("What is the application name? {||}")]
            public string ReportApplicationName { get; set; }
            [Prompt("Please enter the emotion name?  {||}")]
            public string EmotionName { get; set; }
            [Prompt("What is starting date (MM-DD-YYYY) for report?{||}")]
            public string StartDate { get; set; }
            [Prompt("What is the end date (MM-DD-YYYY) for report? {||}")]
            public string EndDate { get; set; }
            public string ReportRequest = string.Empty;
            public static IForm<StandardInfoForm> BuildForm()
            {
                var parser = new Parser();
                return new FormBuilder<StandardInfoForm>()
                    .Message("Welcome to reporting information!!")
                    .Field(new FieldReflector<StandardInfoForm>(nameof(Report))
                                .SetActive(state => state.AskToChooseReport)
                                .SetNext(SetNext))
                    .Field(nameof(ReportApplicationName), state => state.ReportRequest.Contains("application"))
                    .Field(nameof(EmotionName), state => state.ReportRequest.Contains("emotionname"))
                    .Field(nameof(StartDate))
                    .Field(nameof(EndDate))//, EndReportDateActive)
                    .Confirm("Would you like to confirm.Yes or No")
                .Build();
            }
            private static NextStep SetNext(object value, StandardInfoForm state)
            {
                var selection = (ReportType)value;
                if (selection == ReportType.Application)
                {
                    state.ReportRequest = "application";
                    return new NextStep(new[] { nameof(ReportApplicationName) });
                }
                else if (selection == ReportType.Feelings)
                {
                    state.ReportRequest = "emotionname";
                    return new NextStep(new[] { nameof(EmotionName) });
                }
                else if (selection == ReportType.AppVsEmotion)
                {
                    state.ReportRequest = "application,emotionname";
                    return new NextStep(new[] { nameof(ReportApplicationName) });
                }
                else if (selection == ReportType.Help)
                {
                    state.ReportRequest = "application,emotionname";
                    return new NextStep(new[] { nameof(ReportApplicationName) });
                }
                else
                {
                    return new NextStep();
                }
            }
