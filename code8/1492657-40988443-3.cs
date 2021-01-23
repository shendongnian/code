    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    
    namespace ServiceTest
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string TestMethod(ServiceDto dto);
        }
    
        [DataContract]
        public class ServiceDto
        {
            [DataMember]
            [DtoProperty(10)]
            public string DtoField { get; set; }
        }
    
        [DataContract]
        [AttributeUsage(AttributeTargets.Property)]
        public class DtoPropertyAttribute : Attribute
        {
            [DataMember]
            public int MaximumLength { get; set; }
    
            public DtoPropertyAttribute(int maximumLength)
            {
                MaximumLength = maximumLength;
            }   
        }
    }
