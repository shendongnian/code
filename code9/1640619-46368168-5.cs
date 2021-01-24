        public static string AuthOrCharge(this ARequest ThisRequest, bool ur = false)
        {
            ThisRequest.DoCommonAuthOrCharge(ur);
            // do my ARequest specific things here
        }
        ...
        public static string DoCommonAuthOrCharge(this BaseRequest ThisRequest, bool ur = false)
        {
            // do my common things here
        }
