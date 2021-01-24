                Mat currentMat;
                using (MemoryStream memoryStream = new MemoryStream(currentEdges))
                {
                    byte[] rawData = new byte[memoryStream.Length];
                    memoryStream.Read(rawData, 0, (int)memoryStream.Length);
                    GCHandle rawDataHandle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
                    IntPtr address = rawDataHandle.AddrOfPinnedObject();
                    currentMat = new Mat(new System.Drawing.Size(width, height), DepthType.Cv8U, 1, address, width);
                    rawDataHandle.Free();
                }
                Image<Gray, byte> currentImage = currentMat.ToImage<Gray, byte>();
                Mat templateMat;
                using (MemoryStream memoryStream = new MemoryStream(referenceImage.Edges))
                {
                    byte[] rawData = new byte[memoryStream.Length];
                    memoryStream.Read(rawData, 0, (int)memoryStream.Length);
                    GCHandle rawDataHandle = GCHandle.Alloc(rawData, GCHandleType.Pinned);
                    IntPtr address = rawDataHandle.AddrOfPinnedObject();
                    templateMat = new Mat(new System.Drawing.Size(referenceImage.Width_px, referenceImage.Height_px), DepthType.Cv8U, 1, address, referenceImage.Width_px);
                    rawDataHandle.Free();
                }
                Image<Gray, byte> templateImage = templateMat.ToImage<Gray, byte>();
                Image<Gray, float> imgMatch = currentImage.MatchTemplate(templateImage, TemplateMatchingType.CcoeffNormed);
