    public enum PrivilegeType
    {
        [Description("Access not allowed")]
        NoPermissions = 1,
        [Description("Read only ")]
        ViewOnly = 2,
        [Description("Read and write access")]
        ViewAndUpdate = 3
    }
