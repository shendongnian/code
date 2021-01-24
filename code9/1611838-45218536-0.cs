        public class Device
        {
            private string AccessibleRemotelyStr { get; set; }
            public bool AccessibleRemotely
            {
                get
                {
                    return string.Equals(AccessibleRemotelyStr, "Yes", StringComparison.OrdinalIgnoreCase);
                }
                set
                {
                    AccessibleRemotelyStr = value ? "Yes" : "No";
                }
            }
        }
        public class DeviceConfiguration : EntityTypeConfiguration<Device>
        {
            public DeviceConfiguration()
            {
                Property(p => p.AccessibleRemotelyStr).HasColumnName("AccessibleRemotely");
                Ignore(p => p.AccessibleRemotely);
            }
        }
