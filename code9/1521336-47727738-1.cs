    Private Function JsScriptResult(script As String, timeout As Integer) As JavascriptResponse
       If browserTabControl.SelectedIndex = -1 Then
          Return Nothing
       End If
       Dim tabBrowser As BrowserTabUserControl = CType(browserTabControl.TabPages(browserTabControl.SelectedIndex).Controls(0), BrowserTabUserControl)
       Dim frame As IFrame = tabBrowser.Browser.GetFocusedFrame()
       'Execute extension method
       Dim Task As Task(Of JavascriptResponse) = frame.EvaluateScriptAsync(script, timeout:=TimeSpan.FromMilliseconds(timeout))
       Task.Wait()
       Return Task.Result
    End Function
    Sub test() Handles ConnexionMdhMenuItem.Click
       Dim result As JavascriptResponse
       ' get a list of input elements with an id 
       Dim script As String = "
         var els = document.getElementsByTagName('input');
         var t = [];
         for (i=0;i<els.length;i++)
           if (els[i].id) t.push(els[i].id);
         t.join('\n');"
    
       result = JsScriptResult(script, 5000)
       If Not result.Success Then
          MsgBox(result.Message, MsgBoxStyle.Exclamation, "Script error")
          Return
       End If
       'get value for an element with given id
       Dim id As String = Interaction.InputBox(result.Result.ToString, "Id to search ?")
       If id.Length > 0 Then
          result = JsScriptResult($"document.getElementById('{id}').value;", 1000)
          MsgBox($"Result = {result.Result}{vbCr}Message = {result.Message}",
                   If(result.Success, MsgBoxStyle.Information, MsgBoxStyle.Exclamation), "Script result")
       End If
    End Sub
