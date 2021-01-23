System.Devices.DevObjectType:=5 
AND System.Devices.Aep.ProtocolId:="{E0CBF06C-CD8B-4647-BB8A-263B43F0F974}" 
AND (
  System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#True 
  OR System.Devices.Aep.Bluetooth.IssueInquiry:=System.StructuredQueryType.Boolean#False
)
## Unpaired
System.Devices.DevObjectType:=5 
AND System.Devices.Aep.ProtocolId:="{E0CBF06C-CD8B-4647-BB8A-263B43F0F974}" 
AND (
  System.Devices.Aep.IsPaired:=System.StructuredQueryType.Boolean#False 
  OR System.Devices.Aep.Bluetooth.IssueInquiry:=System.StructuredQueryType.Boolean#True
)
What do you think is tested by the expression in parentheses?
What do you think might happen if you omit this clause from the string you supply to `CreateWatcher`?
Something less obvious that you may find helpful is the fact that there are _two_ Bluetooth protocol identifiers. The one shown above is for classic Bluetooth and the query does not match BLE (Bluetooth Low Energy) devices.
The selector I suggest you use is
System.Devices.DevObjectType:=5 
AND (
  System.Devices.Aep.ProtocolId:="{BB7BB05E-5972-42B5-94FC-76EAA7084D49}" 
  OR System.Devices.Aep.ProtocolId:="{E0CBF06C-CD8B-4647-BB8A-263B43F0F974}#"
)
I have put line breaks in all these queries to help you read them. Don't include them in your code. For convenience here's some code from one of my projects.
string BleSelector = "System.Devices.DevObjectType:=5 AND (System.Devices.Aep.ProtocolId:=\"{BB7BB05E-5972-42B5-94FC-76EAA7084D49}\" OR System.Devices.Aep.ProtocolId:=\"{E0CBF06C-CD8B-4647-BB8A-263B43F0F974}\")";
string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.ProtocolId" };
deviceWatcher = DeviceInformation.CreateWatcher(BleSelector, requestedProperties, DeviceInformationKind.AssociationEndpoint);
