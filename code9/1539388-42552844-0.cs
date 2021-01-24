        public sealed class Time/* Class Time for PSX*/
        {
            private Time()
            {
            }//ctor
            private static object _oLock = new object();
            private static Time _it;
            public static Time _IT 
            { 
                get 
                { 
                    if(_it == null)
                        lock(_oLock)
                            if (_it == null)
                                _it = new Time();
                    return _it;
                }
            }
            internal void waitTimer(Int32 TimeLength) //Wait timer
            {
                System.Threading.Thread.Sleep(TimeLength);
            }
            internal struct User_Time
            {
                public const int RefreshData = 100;
                public const int WaitSynchro = 10;
            }
            internal struct TLength_System    //time length definitions for system time
            {
                public const double Time10ms = 10;
                public const double Time50ms = 50;
            }
            internal struct TLength_Form      //time length definitions for Form time
            {
                public const int Time10ms = 10;
                public const int Time50ms = 50;
            }
        }
