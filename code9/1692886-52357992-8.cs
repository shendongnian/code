    using Grpc.Core;
    public class Descriptors
    {
        public static Method<AdditionRequest, AdditionResponse> Method =
                new Method<AdditionRequest, AdditionResponse>(
                    type: MethodType.DuplexStreaming,
                    serviceName: "AdditonService",
                    name: "AdditionMethod",
                    requestMarshaller: Marshallers.Create(
                        serializer: Serializer<AdditionRequest>.ToBytes,
                        deserializer: Serializer<AdditionRequest>.FromBytes),
                    responseMarshaller: Marshallers.Create(
                        serializer: Serializer<AdditionResponse>.ToBytes,
                        deserializer: Serializer<AdditionResponse>.FromBytes));
    }
