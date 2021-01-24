      public IEnumerable<AlarmMode> EnumAlarmModes
        {
            get
            {
                return Enum.GetValues(typeof(AlarmMode)).Cast<AlarmMode>();
            }
        }
