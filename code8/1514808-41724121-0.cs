    class Program
    {
        static void Main(string[] args)
        {
            var s = @"<Parameters>
    <UserProfileState>1</UserProfileState>
    <Parameter>
        <Name>Country</Name>
        <Type>String</Type>
        <Nullable>false</Nullable>
        <AllowBlank>false</AllowBlank>
        <MultiValue>true</MultiValue>
        <UsedInQuery>true</UsedInQuery>
        <State>MissingValidValue</State>
        <Prompt>Country</Prompt>
        <DynamicPrompt>false</DynamicPrompt>
        <PromptUser>true</PromptUser>
        <DynamicValidValues>true</DynamicValidValues>
        <DynamicDefaultValue>true</DynamicDefaultValue>
    </Parameter>
    <Parameter>
        <Name>City</Name>
        <Type>String</Type>
        <Nullable>false</Nullable>
        <AllowBlank>false</AllowBlank>
        <MultiValue>true</MultiValue>
        <UsedInQuery>true</UsedInQuery>
        <State>MissingValidValue</State>
        <Prompt>City</Prompt>
        <DynamicPrompt>false</DynamicPrompt>
        <PromptUser>true</PromptUser>
        <Dependencies>
            <Dependency>Country</Dependency>
        </Dependencies>
        <DynamicValidValues>true</DynamicValidValues>
        <DynamicDefaultValue>true</DynamicDefaultValue>
    </Parameter>
    </Parameters>";
            var serializer = new XmlSerializer(typeof(ParametersModel));
            using (var reader = new StringReader(s))
            {
                var result = (ParametersModel)serializer.Deserialize(reader);
            }
        }
    }
    [Serializable]
    [XmlRoot(ElementName ="Parameters")]
    public class ParametersModel
    {
        [XmlElement]
        public int UserProfileState { get; set; }
        [XmlElement("Parameter")]
        public List<ParameterModel> Parameters { get; set; }
    }
    [Serializable]
    public class ParameterModel
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Type { get; set; }
        [XmlElement]
        public bool Nullable { get; set; }
        [XmlElement]
        public bool AllowBlank { get; set; }
        [XmlElement]
        public bool MultiValue { get; set; }
        [XmlElement]
        public bool UsedInQuery { get; set; }
        [XmlElement]
        public string State { get; set; }
        [XmlElement]
        public string Prompt { get; set; }
        [XmlElement]
        public bool DynamicPrompt { get; set; }
        [XmlElement]
        public bool PromptUser { get; set; }
        [XmlElement]
        public bool DynamicValidValues { get; set; }
        [XmlElement]
        public bool DynamicDefaultValue { get; set; }
    }
