    Public currentUrlIndex As Integer = Nothing, currentUrl As String = Nothing
        Public Sub customNavigation()
           
                            testWebBrowserForm = New WebBrowserForm(Me)
                            Dim browserSize As System.Drawing.Size = New Size(100, 100)
                            testWebBrowserForm.Size = browserSize
                            testWebBrowserForm.FormBorderStyle = FormBorderStyle.FixedSingle
                            testWebBrowserForm.Show()
                            testWebBrowserForm.SendToBack()
                            testWebBrowserForm.Location = New Point(100, 100)
                            currentUrlIndex = 0
                            currentUrl = listOfUrls(currentUrlIndex)
                            testWebBrowserForm.Navigate(New Uri(currentUrl))
                        
        End Sub
        
        // Once the document has completely loaded
        Public Sub documentLoadComplete()
        
                Dim submitButton As HtmlElement = Nothing, formEl As HtmlElement = Nothing
        
                Dim attachmentInputElements As Windows.Forms.HtmlElementCollection = testWebBrowserForm.webBrowser.Document.GetElementsByTagName("input")
                Dim formElements As Windows.Forms.HtmlElementCollection = testWebBrowserForm.webBrowser.Document.Forms
                Dim form As Windows.Forms.HtmlElement = testWebBrowserForm.webBrowser.Document.Forms(0)
        
                For y = 0 To formElements.Count - 1
                    Dim formelement As HtmlElement = formElements(y)
                    If formelement.GetAttribute("name").Equals("theForm") Then
                        formEl = formelement
                    End If
                Next
        
                For i = 0 To attachmentInputElements.Count - 1
                    Dim inputElement As HtmlElement = attachmentInputElements(i)
                    If inputElement.GetAttribute("type").Equals("submit") Then
                        submitButton = inputElement
                    End If
                Next
        
                testWebBrowserForm.webBrowser.Document.InvokeScript("doSomething")
        
                submitButton.InvokeMember("click")
        
                If currentUrlIndex = listOfUrls.Count - 1 Then
                        testWebBrowserForm.Close()
                        Exit Sub
                    Else
                        currentUrlIndex = currentUrlIndex + 1
                        currentUrl = listOfUrls(currentUrlIndex)
                        testWebBrowserForm.Navigate(New Uri(currentUrl))
                    End If
        End Sub
