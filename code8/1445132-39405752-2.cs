    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    class Core
    {
        public static void Main(string[] args)
        {
            SystemTime MySystemTime = new SystemTime(DateTime.Now);
            StringBuilder MyStringBuilder = new StringBuilder();
            int Result = GetTimeFormat(0, 0, ref MySystemTime, "hh':'mm':'ss", MyStringBuilder, 128);
            uint ErrorCode = GetLastError(); // Reference: https://msdn.microsoft.com/en-us/library/windows/desktop/ms681382(v=vs.85).aspx
            Console.ReadKey(true);  
        }
        [DllImport("kernel32.dll")]
        static extern int GetTimeFormat(uint locale, uint dwFlags, ref SystemTime time, string format, StringBuilder sb, int sbSize);
        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        internal struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Milliseconds;
            public SystemTime(DateTime dt)
            {
                dt = dt.ToUniversalTime();
                Year = Convert.ToUInt16(dt.Year);
                Month = Convert.ToUInt16(dt.Month);
                DayOfWeek = Convert.ToUInt16(dt.DayOfWeek);
                Day = Convert.ToUInt16(dt.Day);
                Hour = Convert.ToUInt16(dt.Hour);
                Minute = Convert.ToUInt16(dt.Minute);
                Second = Convert.ToUInt16(dt.Second);
                Milliseconds = Convert.ToUInt16(dt.Millisecond);
            }
            public SystemTime(ushort year, ushort month, ushort day, ushort hour = 0, ushort minute = 0, ushort second = 0, ushort millisecond = 0)
            {
                Year = year;
                Month = month;
                Day = day;
                Hour = hour;
                Minute = minute;
                Second = second;
                Milliseconds = millisecond;
                DayOfWeek = 0;
            }
            public static implicit operator DateTime(SystemTime st)
            {
                if (st.Year == 0 || st == MinValue)
                    return DateTime.MinValue;
                if (st == MaxValue)
                    return DateTime.MaxValue;
                return new DateTime(st.Year, st.Month, st.Day, st.Hour, st.Minute, st.Second, st.Milliseconds, DateTimeKind.Local);
            }
            public static bool operator ==(SystemTime s1, SystemTime s2)
            {
                return (s1.Year == s2.Year && s1.Month == s2.Month && s1.Day == s2.Day && s1.Hour == s2.Hour && s1.Minute == s2.Minute && s1.Second == s2.Second && s1.Milliseconds == s2.Milliseconds);
            }
            public static bool operator !=(SystemTime s1, SystemTime s2)
            {
                return !(s1 == s2);
            }
            public static readonly SystemTime MinValue, MaxValue;
            static SystemTime()
            {
                MinValue = new SystemTime(1601, 1, 1);
                MaxValue = new SystemTime(30827, 12, 31, 23, 59, 59, 999);
            }
            public override bool Equals(object obj)
            {
                if (obj is SystemTime)
                    return ((SystemTime)obj) == this;
                return base.Equals(obj);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
