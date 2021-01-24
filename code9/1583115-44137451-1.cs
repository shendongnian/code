    MyResponseClass result1 = new MyResponseClass
    {
        Response = new Response
        {
            Sid = "(sid string)",
            Error = new Error
            {
                ErrorMessage = "error message text"
            }
        }
    };
    var serializer = new XmlSerializer(typeof(MyResponseClass));
    string serialized = "";
    using (StringWriter textWriter = new StringWriter())
    {
        serializer.Serialize(textWriter, result1);
        serialized = textWriter.ToString();
    }
