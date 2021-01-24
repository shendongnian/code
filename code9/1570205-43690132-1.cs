       Public Shared Function SerializeXML(ByVal data As Object) As Byte()
            Dim ser As XmlSerializer = New XmlSerializer(data.GetType)
            Dim xBuff As New StringWriter
            ser.Serialize(xBuff, data)
            Return System.Text.Encoding.Unicode.GetBytes(xBuff.ToString)
        End Function
        Public Shared Function DeSerializeXML(Of T)(ByVal data As Byte()) As T
            Dim ser As New XmlSerializer(GetType(T))
            Dim XbUF As New MemoryStream
            XbUF.Write(data, 0, data.Length)
            XbUF.Position = 0
            Return ser.Deserialize(XbUF)
        End Function
