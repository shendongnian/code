private static bool addPushAndAssociatedDomainCapability(PBXProject project, string pathToBuildProject)
    {
        var targetName = PBXProject.GetUnityTargetName();
        var targetGuid = project.TargetGuidByName(targetName);
        var productName = project.GetBuildPropertyForAnyConfig(targetGuid, "PRODUCT_NAME");
        var fileName = productName + ".entitlements";
        var entitleFilePath = pathToBuildProject + "/" + targetName + "/" + fileName;
        if (File.Exists(entitleFilePath) == true)
        {
            Debug.Log("[Builder] entitle file exist.");
            return true;
        }
        bool success = project.AddCapability(targetGuid, PBXCapabilityType.PushNotifications);
        if (success ==false)
        {
            Debug.Log("[Builder] open push cabability fail.");
            return false;
        }
        success = project.AddCapability(targetGuid, PBXCapabilityType.AssociatedDomains);
        const string entitlements = @"
     <?xml version=""1.0"" encoding=""UTF-8\""?>
     <!DOCTYPE plist PUBLIC ""-//Apple//DTD PLIST 1.0//EN"" ""http://www.apple.com/DTDs/PropertyList-1.0.dtd"">
     <plist version=""1.0"">
         <dict>
             <key>aps-environment</key>
             <string>development</string>
             <key>com.apple.developer.associated-domains</key>
             <array>
                <string>xxx</string>
             </array>
         </dict>
     </plist>";
        try
        {
            File.WriteAllText(entitleFilePath, entitlements);
            project.AddFile(targetName + "/" + fileName, fileName);
            project.AddBuildProperty(targetGuid, "CODE_SIGN_ENTITLEMENTS", targetName + "/" + fileName);
        }
        catch (IOException e)
        {
            Debug.LogError("Could not copy entitlements. Probably already exists." + e);
        }
        Debug.Log("[Builder] add push capability success.");
        return true;
    }
