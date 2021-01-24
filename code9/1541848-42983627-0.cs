    public float[] GetVector(Image<Bgr, Byte> img)
            {
                HOGDescriptor hog = new HOGDescriptor();    // with defaults values
               
                return hog.Compute(img, new Size(8, 8), new Size(0, 0), null);
            }
