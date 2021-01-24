            internal void Detect(IEnumerable<string> fileNames, Action<ShapeInfo> detected)
            {
                foreach (var fn in fileNames)
                    using (Mat mat = getMat(fn, false))
                    {
                        {
                            using (var samples = mat.Reshape(0, 1))
                            {
                                if (samples.Depth != DepthType.Cv32F)
                                    samples.ConvertTo(samples, DepthType.Cv32F);
                                CvInvoke.Normalize(samples, samples, -1, 1, NormType.MinMax);
                                foreach (var svm in this.svms)
                                {
                                    float p = svm.Predict(samples, null);
                                      
                                }
                            }
                        }
                    }
            }
