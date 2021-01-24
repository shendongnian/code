    private JavascriptResponse JsScriptResult(string script, int timeout)
    {
        if (browserTabControl.SelectedIndex == -1)
          {return null;}
    
        BrowserTabUserControl tabBrowser = (BrowserTabUserControl)browserTabControl.TabPages(browserTabControl.SelectedIndex).Controls(0);
        IFrame frame = tabBrowser.Browser.GetFocusedFrame();
        Task<JavascriptResponse> Task = frame.EvaluateScriptAsync(script, timeout: TimeSpan.FromMilliseconds(timeout));
        Task.Wait();
        return Task.Result;
    }
    
    private void test()
    {
        JavascriptResponse result;
        // get a list of input elements with an id 
        string script = "var els = document.getElementsByTagName('input');\n var t = [];\nfor (i=0;i<els.length;i++)\n  if (els[i].id) t.push(els[i].id);\n t.join('\\n');";
        result = JsScriptResult(script, 5000);
        if (!result.Success)
        {
            MsgBox(result.Message, MsgBoxStyle.Exclamation, "Script error");
            return;
        }
        // get value for an element with given id
        string id = InputBox(result.Result.ToString, "Id to search ?");
        if (id.Length > 0){
            result = JsScriptResult($"document.getElementById('{id}').value;", 1000);
            MsgBox($"Result = {result.Result}\nMessage = {result.Message}", result.Success ? MsgBoxStyle.Information : MsgBoxStyle.Exclamation, "Script result");
        }
    }
