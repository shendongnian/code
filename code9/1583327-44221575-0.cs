    public class LexSavableModelBase<T> : SavableModelBase<T> where T : class
    {
        // SNIP!
        public static new T Load(Stream stream, SerializationMode mode)
        {
            Argument.IsNotNull(() => stream);
            if (mode == SerializationMode.Xml)
            {
                using (XmlReader xr = XmlReader.Create(stream))
                {
                    xr.MoveToContent();
                    string rootName = xr.LocalName;
                    if (string.Compare(rootName, typeof(T).Name, StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        throw new InvalidDataException(string.Format(CultureInfo.CurrentCulture, "Expecting data from Model [{0}], but found Model [{1}] instead.", typeof(T).Name, rootName));
                    }
                    // Reset to read from the top.
                    stream.Seek(0, SeekOrigin.Begin);
                }
            }
            return SavableModelBase<T>.Load<T>(stream, mode);
        }
    }
