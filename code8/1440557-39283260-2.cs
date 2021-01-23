    public static class IntrinsicCameraParametersExtensions
    {
        public static void SerializeIntrinsicCameraParametersExtensionsToXmlFile(this IntrinsicCameraParameters icp, string fileName)
        {
            var surrogate = (Emgu.CV.SerializationSurrogates.IntrinsicCameraParameters)icp;
            surrogate.SerializeToXmlFile(fileName);
        }
        public static IntrinsicCameraParameters DeserializeIntrinsicCameraParametersFromXmlFile(string fileName)
        {
            var surrogate = XmlSerializationExtensions.DeserializeFromXmlFile<Emgu.CV.SerializationSurrogates.IntrinsicCameraParameters>(fileName);
            return surrogate;
        }
    }
