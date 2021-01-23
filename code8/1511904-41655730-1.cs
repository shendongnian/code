    Dim webCL As New System.Net.WebClient
        Dim PublicIP As String = ""
        Try
            Dim foo As New Xml.XmlDocument
            foo.LoadXml(System.Text.Encoding.ASCII.GetString((webCL.DownloadData("http://checkip.dyndns.org/"))))
            Dim curNode As Xml.XmlNode = foo.DocumentElement.FirstChild
            curNode = curNode.NextSibling
            response = curNode.InnerText.Remove(0, curNode.InnerText.IndexOf(":") + 1)
        Catch ex As Exception
            PublicIP = "ERROR"
        End Try
          If PublicIP = Database_Sever_IP Then
              If dbHost = Hst.Internet Then
                  dbHost = Hst.Network
                  ForcedToNetwork = True
              End If
          End If
