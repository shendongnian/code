    public abstract class DeviceGroupManagerBase<TDeviceGroup> where TDeviceGroup : DeviceGroup
    {
        public abstract IDeviceGroupDao<TDeviceGroup> DeviceGroupDao { get; }
        public TDeviceGroup UpdateDeviceIndexes(Device device)
        {
            return DeviceGroupDao.GetDeviceGroup(device.Group.Id);
        }
    }
