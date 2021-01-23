    using Cognifide.PowerShell.Core.Host;
    using Sitecore.Data.Items;
    
    namespace MyProject
    {
        public class TestSPE
        {
            public void Invoke()
            {
                using (ScriptSession scriptSession = ScriptSessionManager.NewSession("Default", true))
                {
                    Item speScriptItem = Sitecore.Context.Database.GetItem("/path-or-id/to-spe-item");
                    string script = speScriptItem["Script"];
                    if (!string.IsNullOrEmpty(script))
                        scriptSession.ExecuteScriptPart(script);
                }
            }
        }
    }
