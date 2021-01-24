    public class SessionCatchingModule : IHttpModule //You will need to import System.Web
    {
        public void Init(HttpApplication context)
        {
            //Get the SessionstateModule and attach our own events to it
            var module = context.Modules["Session"] as SessionStateModule;
            if (module != null)
            {
                module.Start += this.Session_Start;
                module.End += this.Session_end;
            }
        }
        private void Session_Start(object sender, EventArgs args)
        {
            //Oh look, a session has started
        }
        private void Session_End(object sender, EventArgs args)
        {
            //Oh look, a session has ended
        }
    }
