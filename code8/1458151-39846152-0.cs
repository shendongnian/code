    struct Action_t
    {
        public ActionEventType_e type = AE_TYPE_UNKNOWN;
        public UInt32 repeat_interval = 0;
        public UInt32 repeat_duration = 0;
        public DeviceType_e device = DEV_TYPE_UNKNOWN;
        public bool isDone = false;
    }
