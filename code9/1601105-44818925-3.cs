    var xml = @"
        <Batch>
            <description>example</description>
            <fileField>DesktopA</fileField>
            <output>The</output>
            <input>home</input>
            <input>green</input>
            <parameters>
                <action>1</action>
                <item>2</item>          
            </parameters>
            <parameters>
                <action>1</action>
                <item>4</item>          
            </parameters>
        </Batch>";
    var serializer = new XmlSerializer(typeof(Batch));
    var textReader = new StringReader(xml);
    var obj = (Batch) serializer.Deserialize(textReader);
