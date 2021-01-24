       If serverVersion > localVersion Then
    		Dim url As New Uri(sUrlToReadFileFrom)
    		Dim request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create(url), System.Net.HttpWebRequest)
    		Dim response As System.Net.HttpWebResponse = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
    		response.Close()
    
    		Dim iSize As Int64 = response.ContentLength
    
    		Dim iRunningByteTotal As Int64 = 0
    
    		Using client As New System.Net.WebClient()
    			Using streamRemote As System.IO.Stream = client.OpenRead(New Uri(sUrlToReadFileFrom))
    				Using streamLocal As Stream = New FileStream(sFilePathToWriteFileTo, FileMode.Create, FileAccess.Write, FileShare.None)
    					Dim iByteSize As Integer = 0
    					Dim byteBuffer As Byte() = New Byte(iSize - 1) {}
    					While (InlineAssignHelper(iByteSize, streamRemote.Read(byteBuffer, 0, byteBuffer.Length))) > 0
    						streamLocal.Write(byteBuffer, 0, iByteSize)
    						iRunningByteTotal += iByteSize
    
    						Dim dIndex As Double = CDbl(iRunningByteTotal)
    						Dim dTotal As Double = CDbl(byteBuffer.Length)
    						Dim dProgressPercentage As Double = (dIndex / dTotal)
    						Dim iProgressPercentage As Integer = CInt(dProgressPercentage * 100)
    
    						backgroundWorker1.ReportProgress(iProgressPercentage)
    					End While
    
    					streamLocal.Close()
    				End Using
    
    				streamRemote.Close()
    			End Using
    		End Using
    	End If
