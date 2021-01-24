        public void SetZoomPositionSetting(PropertyID propID, Point value, int inParam = 0)
        {
            CheckState();
            int size = Marshal.SizeOf(typeof(Point));
            ErrorCode err = CanonSDK.EdsSetPropertyData(CamRef, propID, inParam, size, value);
        }
