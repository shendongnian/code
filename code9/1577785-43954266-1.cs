    // First, read a NodeSet2.xml file from a stream.
    var nodeSet = UANodeSet.Read(istrm); 
    // Then create an empty NodeStateCollection.
    var nodes = new NodeStateCollection();
    
    // Update namespace table
    if (nodeSet.NamespaceUris != null && context.NamespaceUris != null)
    {
       for (int ii = 0; ii < nodeSet.NamespaceUris.Length; ii++)
       {
           context.NamespaceUris.GetIndexOrAppend(nodeSet.NamespaceUris[ii]);
           namespaceUris.Add(nodeSet.NamespaceUris[ii]);
        }
    }
    // Update server table
    if (nodeSet.ServerUris != null && context.ServerUris != null)
    {
        for (int ii = 0; ii < nodeSet.ServerUris.Length; ii++)
        {
            context.ServerUris.GetIndexOrAppend(nodeSet.ServerUris[ii]);
        }
    }
    // Convert the nodeset to nodeState collection, aka predefinedNodes. 
    nodeSet.Import(context, nodes);
 
https://github.com/OPCFoundation/UA-.NETStandard/blob/3c1159ec712db4403d2dc9840b3e9525f56610b3/Stack/Opc.Ua.Core/Schema/UANodeSetHelpers.cs#L113
https://github.com/OPCFoundation/UA-.NETStandard/blob/cd4173aa95abd296578b976be67485c299473a70/Stack/Opc.Ua.Core/Schema/UANodeSetHelpers.cs#L113
  [1]: https://github.com/OPCFoundation/UA-.NETStandard
