    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using JObject = System.Collections.Generic.Dictionary<string, object>;
    class ChromeDriverEx : ChromeDriver
    {
        public ChromeDriverEx(ChromeOptions options = null) 
            : base(options ?? new ChromeOptions()) {
            var repo = base.CommandExecutor.CommandInfoRepository;
            repo.TryAddCommand("send", new CommandInfo("POST", "/session/{sessionId}/chromium/send_command_and_get_result"));
        }
        public new Screenshot GetScreenshot() {
            object response = Send("Page.captureScreenshot", new JObject {{"format", "png"}, {"fromSurface", true}});
            string base64 = (string)((JObject)response)["data"];
            return new Screenshot(base64);
        }
        protected object Send(string cmd, JObject args) {
            return this.Execute("send",  new JObject {{"cmd", cmd}, {"params", args}}).Value;
        }
    }
