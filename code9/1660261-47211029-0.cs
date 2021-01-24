    public static IQueryable<CustomerDevice> ToCustomerDevice(this IQueryable<PTT_CUSTOMER_DEVICES> devices)
    {
        return devices.Select(d => new CustomerDevice
        {
            customerAssetTag = d.CustomerAssetTag,
            customerDeviceID = d.CustomerDeviceID
        }
    }
