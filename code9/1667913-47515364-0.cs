    Private Async Sub AAA(campanaRep As ClassInstance)
    	Using client As New System.Net.Http.HttpClient()
    		client.BaseAddress = New Uri("")
    		client.DefaultRequestHeaders.Accept.Clear()
    		Dim response As System.Net.Http.HttpResponseMessage = _
                Await client.PutAsJsonAsync("Http"+ "WebMethod", campanaRep)
       		If (response.IsSuccessStatusCode)
    			bol = Await response.Content.ReadAsAsync(Of Boolean)
    		End If
        End Using
    End Sub
