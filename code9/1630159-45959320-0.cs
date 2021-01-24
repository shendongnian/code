    var networkInfoType = Type.GetType("Windows.Networking.Connectivity.NetworkInformation, Windows, ContentType=WindowsRuntime");
                var profileType = Type.GetType("Windows.Networking.Connectivity.NetworkInformation, Windows, ContentType=WindowsRuntime");
                var profileObj = networkInfoType.GetTypeInfo().GetDeclaredMethod("GetInternetConnectionProfile").Invoke(null, null);
                dynamic profDyn = profileObj;
                var costObj = profDyn.GetConnectionCost();
                dynamic dynCost = costObj;
    
                var costType = (NetworkCostType)dynCost.NetworkCostType;
                if (costType == NetworkCostType.Unknown
                        || costType == NetworkCostType.Unrestricted)
                {
                    //Connection cost is unknown/unrestricted
                }
                else
                {
                    //Metered Network
                }
