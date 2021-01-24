    public interface IDeviceNetwork
    {
        bool IsWifiEnabled();
        bool IsWifiConnected();
        NetworkState GetNetworkState();
    }
