    System.Runtime.Serialization.SerializationException: Cannot find assembly 'DummyAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Server stack trace:
       w System.Runtime.Serialization.Formatters.Binary.BinaryAssemblyInfo.GetAssembly()
       w System.Runtime.Serialization.Formatters.Binary.ObjectReader.GetType(BinaryAssemblyInfo assemblyInfo, String name)
       w System.Runtime.Serialization.Formatters.Binary.ObjectMap..ctor(String objectName, String[] memberNames, BinaryTypeEnum[] binaryTypeEnumA, Object[] typeInformationA, Int32[] memberAssemIds, ObjectReader objectReader, Int32 objectId, BinaryAssemblyInfo assemblyInfo, SizedArray assemIdToAssemblyTable)
       w System.Runtime.Serialization.Formatters.Binary.__BinaryParser.ReadObjectWithMapTyped(BinaryObjectWithMapTyped record)
       w System.Runtime.Serialization.Formatters.Binary.__BinaryParser.ReadObjectWithMapTyped(BinaryHeaderEnum binaryHeaderEnum)
       w System.Runtime.Serialization.Formatters.Binary.__BinaryParser.Run()
       w System.Runtime.Serialization.Formatters.Binary.ObjectReader.Deserialize(HeaderHandler handler, __BinaryParser serParser, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
       w System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream, HeaderHandler handler, Boolean fCheck, Boolean isCrossAppDomain, IMethodCallMessage methodCallMessage)
       w System.Runtime.Remoting.Channels.CrossAppDomainSerializer.DeserializeObject(MemoryStream stm)
       w System.Runtime.Remoting.Messaging.SmuggledMethodReturnMessage.FixupForNewAppDomain()
       w System.Runtime.Remoting.Channels.CrossAppDomainSink.SyncProcessMessage(IMessage reqMsg)
    
    Exception rethrown at [0]:
       w System.Runtime.Remoting.Proxies.RealProxy.HandleReturnMessage(IMessage reqMsg, IMessage retMsg)
       w System.Runtime.Remoting.Proxies.RealProxy.PrivateInvoke(MessageData& msgData, Int32 type)
       w ServerObject.TestMethod1(TestType& result, String v)
