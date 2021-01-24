       private Rectangle GetEvfZoomRect(IntPtr imgRef)
        {
            Rectangle rect = new Rectangle();
            ErrorCode err = CanonSDK.GetPropertyData(imgRef, PropertyID.Evf_ZoomRect, 0, out rect);
            if (err == ErrorCode.OK)
                return rect;
            else
                return rect = new Rectangle();
        }
        private Size GetEvfCoord_Size(IntPtr imgRef)
        {
            Size size = new Size();
            ErrorCode err = CanonSDK.GetPropertyData(imgRef, PropertyID.Evf_CoordinateSystem, 0, out size);
            if (err == ErrorCode.OK)
                return size;
            else
                return new Size();
        }
