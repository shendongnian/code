             ManagementClass virtualSystemManagementServiceClass =
                new ManagementClass(@"root\virtualization\v2:Msvm_VirtualSystemManagementService");
            ManagementBaseObject inParams =
                virtualSystemManagementServiceClass
                    .GetMethodParameters("DefineSystem");
            // Add the input parameters.
            ManagementClass virtualSystemSettingDataClass =
                new ManagementClass(@"root\virtualization\v2:Msvm_VirtualSystemSettingData")
                {
                    ["ElementName"] = "Test"
                };
            // Create Instance of VirtualSystemSettingData
            ManagementObject virtualSystemSettingData = virtualSystemSettingDataClass.CreateInstance();
            inParams["SystemSettings"] =
                virtualSystemSettingData.GetText(TextFormat.CimDtd20);
            // Get Instance of VirtualSystemManagmentService
            ManagementObject virtualSystemManagementService = null;
            foreach (ManagementObject instance in virtualSystemManagementServiceClass.GetInstances())
            {
                virtualSystemManagementService = instance;
                break;
            }
            // Execute the method and obtain the return values.
            ManagementBaseObject outParams = virtualSystemManagementService.InvokeMethod("DefineSystem", inParams, null);
