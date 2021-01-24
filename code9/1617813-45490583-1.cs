    public class MsResourceGroup : ManagementObjectWrapperBase
    {
        public static MsResourceGroup Create(
            ManagementObject fromResourceGroupManagementObject)
        {
            var name = fromResourceGroupManagementObject.GetStringPropertyValue("Name");
            return new MsResourceGroup(
                name: name,
                resourceGroupManagementObject: fromResourceGroupManagementObject);
        }
        private MsResourceGroup(
            string name,
            ManagementObject resourceGroupManagementObject)
            : base(resourceGroupManagementObject)
        {
            Name = name;
        }
        public string Name { get; }
        public void DestroyGroup()
        {
            AsManagementObject.Invoke(
                methodName: "DestroyGroup",
                fillInvocationParameters: inputParameters => { });
        }
    }
