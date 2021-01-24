    [XmlRoot("response")]
    public class Response
    {
        [XmlElement("error")]
        public Error Error { get; set; }
        [XmlElement("sid")]
        public string Sid { get; set; }
    }
...
    var responseString = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><response><error><error_msg>CANNOT_LOGIN</error_msg></error></response>";
    var serializer2 = new XmlSerializer(typeof(Response));
    //using (StringWriter textWriter = new StringWriter())
    //{
    //    serializer2.Serialize(textWriter, result1.Response);
    //    responseString = textWriter.ToString();
    //}
    
    Response result;
    using (var reader = new StringReader(responseString))
    {
        result = (Response)serializer2.Deserialize(reader);
    }
