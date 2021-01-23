        internal static byte[] SerializeArray<T>(T[] array) where T : struct
        {
            if ( array.IsNullOrEmpty() )
                return null;            
            int position = 0;
            int structSize = Marshal.SizeOf(typeof(T));
            if (structSize < 1)
            {
                throw new Exception($"SerializeArray: invalid structSize ({structSize})");
            }
            byte[] rawData = new byte[structSize * array.Length];
            IntPtr buffer = IntPtr.Zero;
            try
            {
                buffer = Marshal.AllocHGlobal(structSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"SerializeArray: Marshal.AllocHGlobal(structSize={structSize}) failed. Message: {ex.Message}");
            }
            try
            {
                int i = 0;
                int total = array.Length;
                foreach (T item in array)
                {
                    try
                    {
                        Marshal.StructureToPtr(item, buffer, false);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"SerializeArray: Marshal.StructureToPtr failed. item={item.ToString()}, index={i}/{total}. Message: {ex.Message}");
                    }
                    try
                    {
                        Marshal.Copy(buffer, rawData, position, structSize);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"SerializeArray: Marshal.Copy failed. item={item.ToString()}, index={i}/{total}. Message: {ex.Message}");
                    }
                    i++;
                    position += structSize;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                try
                {
                    Marshal.FreeHGlobal(buffer);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Marshal.FreeHGlobal failed (buffer={buffer}. Message: {ex.Message}");
                }
            }
            return rawData;
        }
