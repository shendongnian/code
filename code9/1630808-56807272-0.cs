        ///An assertion method that does the only thing that an assertion method is supposed to
        ///do, which is to throw an "Assertion Failed" exception.
        ///(Necessary because System.Diagnostics.Debug.Assert does a whole bunch of useless, 
        ///annoying, counter-productive stuff instead of just throwing an exception.)
        [DebuggerHidden] //this makes the debugger stop in the calling method instead of here.
        [Conditional("DEBUG")]
        public static void Assert(bool expression)
        {
            if (expression)
                return;
            throw new AssertionFailureException();
        }
