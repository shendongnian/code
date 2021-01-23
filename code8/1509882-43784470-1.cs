            /// >>>>Based on [joshuanapoli] answer<<<
            /// <summary>
            /// Get a neighbor index in the heirarchy tree.
            /// </summary>
            /// <returns>
            /// A neighbor index or -1 if the given neighbor does not exist.
            /// </returns>
            //public int Get(HierarchyIndex component, int index)
            //public int GetHierarchy(Mat Hierarchy, int contourIdx, int component)
            public int[] GetHierarchy(Mat Hierarchy, int contourIdx)
            {
                int[] ret = new int[] { };
    
                if (Hierarchy.Depth != Emgu.CV.CvEnum.DepthType.Cv32S)
                {
                    throw new ArgumentOutOfRangeException("ContourData must have Cv32S hierarchy element type.");
                }
                if (Hierarchy.Rows != 1)
                {
                    throw new ArgumentOutOfRangeException("ContourData must have one hierarchy hierarchy row.");
                }
                if (Hierarchy.NumberOfChannels != 4)
                {
                    throw new ArgumentOutOfRangeException("ContourData must have four hierarchy channels.");
                }
                if (Hierarchy.Dims != 2)
                {
                    throw new ArgumentOutOfRangeException("ContourData must have two dimensional hierarchy.");
                }
                long elementStride = Hierarchy.ElementSize / sizeof(Int32);
                var offset0 = (long)0 + contourIdx * elementStride;
                if (0 <= offset0 && offset0 < Hierarchy.Total.ToInt64() * elementStride)
                {
                    
    
                    var offset1 = (long)1 + contourIdx * elementStride;
                    var offset2 = (long)2 + contourIdx * elementStride;
                    var offset3 = (long)3 + contourIdx * elementStride;
    
                    ret = new int[4];
    
                    unsafe
                    {
                        //return *((Int32*)Hierarchy.DataPointer.ToPointer() + offset);
    
                        ret[0] = *((Int32*)Hierarchy.DataPointer.ToPointer() + offset0);
                        ret[1] = *((Int32*)Hierarchy.DataPointer.ToPointer() + offset1);
                        ret[2] = *((Int32*)Hierarchy.DataPointer.ToPointer() + offset2);
                        ret[3] = *((Int32*)Hierarchy.DataPointer.ToPointer() + offset3);
                    }
    
    
                }
                //else
                //{
                //    return new int[] { };
                //}
    
                return ret;
            }
