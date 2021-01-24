    var contractUsingName = new ContractDescription("IProtoBufService");
    var contractUsingNameWithNameSpace = new ContractDescription("IProtoBufService", "http://www.tempuri.org");
    var contractUsingContractType = ContractDescription.GetContract(typeof(IProtoBufService));
    var contractUsingContractTypeAndObjectImp = ContractDescription.GetContract(typeof(IProtoBufService), ProtoBufService);
    var contractUsingContractTypeAndObjectType = ContractDescription.GetContract(typeof(IProtoBufService), typeof(ProtoBufService));
