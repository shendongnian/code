            UMat u = new UMat(new Size(480, 320), DepthType.Cv8U, 1);
            u.SetTo(new MCvScalar(100));
            byte[] value = new byte[1];
            int row = 100;
            int col = 200;
            using (Mat m = u.GetMat(AccessType.Read))
            {
                IntPtr ptr = m.DataPointer + row * m.Step + col * m.ElementSize;
                Marshal.Copy(ptr, value, 0, 1);
            }
