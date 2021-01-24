    [ServiceContract()]
    [XmlSerializerFormat]
    public interface IService1
    {
        [OperationContract(
            // wsdl request action
            Action = Constants.Namespaces.HL7Namespace + ":" + Constants.Interactions.RCMR_IN000029UV01 + "." + Constants.VersionType.NormativeCode + Constants.Version.InteractionVersion,
            // wsdl operation name
            Name = Constants.Interactions.RCMR_IN000029UV01,
            // wsdl response action
            ReplyAction = Constants.Namespaces.HL7Namespace + ":" + Constants.Interactions.RCMR_IN000030UV01 + "." + Constants.VersionType.NormativeCode + Constants.Version.InteractionVersion)]
        SearchMessagesResponse SearchMessages(/* SearchMessagesRequest RCMR_IN000029UV01*/);
    }
