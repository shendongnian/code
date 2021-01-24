     readonly static List<string> WhiteList = new List<string>()
        {
            #region Basics
            typeof(Boolean).FullName,
            typeof(Char).FullName,
            typeof(String).FullName,
            typeof(Byte).FullName,
            typeof(SByte).FullName,
            typeof(UInt16).FullName,
            typeof(Int16).FullName,
            typeof(UInt32).FullName,
            typeof(Int32).FullName,
            typeof(UInt64).FullName,
            typeof(Int64).FullName,
            typeof(Decimal).FullName,
            typeof(Double).FullName,
            typeof(Single).FullName,
            typeof(TimeSpan).FullName,
            typeof(Array).FullName,
            typeof(Enum).FullName,
            #endregion
            #region Exceptions
            typeof(Exception).FullName,
            typeof(NotImplementedException).FullName,
            typeof(IOException).FullName,
            #endregion
            #region Delegates
            typeof(Delegate).FullName,
            #endregion
            #region Parallel
            typeof(Parallel).FullName,
            #endregion
            #region Conversions
            typeof(Convert).FullName,
            typeof(BitConverter).FullName,
            #endregion
            #region Streams
            typeof(Stream).FullName,
            typeof(MemoryStream).FullName,
            typeof(BinaryReader).FullName,
            typeof(BinaryWriter).FullName,
            #endregion
            #region Interfaces
            typeof(IDisposable).FullName,
            typeof(IComparable).FullName,
            typeof(IConvertible).FullName,
            typeof(IFormatProvider).FullName,
            typeof(IFormattable).FullName,
            typeof(IOrderedQueryable).FullName,
            #endregion
            #region Attributes
            typeof(Attribute).FullName,
            
            // Compilation JIT
            typeof(CompilationRelaxationsAttribute).FullName,
            typeof(RuntimeCompatibilityAttribute).FullName,
            typeof(CompilerGeneratedAttribute).FullName,
            #endregion
            #region Generic Types
            typeof(IDictionary<object,object>).Namespace+"."+typeof(IDictionary<object,object>).Name,
            typeof(Dictionary<object,object>).Namespace+"."+typeof(Dictionary<object,object>).Name,
            typeof(List<object>).Namespace+"."+typeof(List<object>).Name,
            typeof(IList<object>).Namespace+"."+typeof(IList<object>).Name,
            typeof(IEnumerable<object>).Namespace+"."+typeof(IEnumerable<object>).Name,
            typeof(IEnumerator<object>).Namespace+"."+typeof(IEnumerator<object>).Name,
            typeof(IOrderedEnumerable<object>).Namespace+"."+typeof(IOrderedEnumerable<object>).Name,
            typeof(IOrderedQueryable<object>).Namespace+"."+typeof(IOrderedQueryable<object>).Name,
            typeof(ICollection<object>).Namespace+"."+typeof(ICollection<object>).Name,
            typeof(IComparable<object>).Namespace+"."+typeof(IComparable<object>).Name,
            typeof(IEquatable<object>).Namespace+"."+typeof(IEquatable<object>).Name,
            typeof(IObservable<object>).Namespace+"."+typeof(IObservable<object>).Name,
            #endregion
        };
        const string WhiteListedNamespace = "XX.XXXXXXXXXX.";
        /// <summary>
        /// Check white list
        /// </summary>
        /// <param name="binary">Binary</param>
        public static void CheckWhiteList(byte[] binary)
        {
            using (MemoryStream ms = new MemoryStream(binary))
            {
                AssemblyDefinition def = AssemblyDefinition.ReadAssembly(ms, new ReaderParameters(ReadingMode.Immediate));
                List<string> ls = new List<string>();
                foreach (ModuleDefinition mdef in def.Modules)
                    foreach (TypeReference tdef in mdef.GetTypeReferences())
                    {
                        if (!WhiteList.Contains(tdef.FullName) &&
                            !tdef.FullName.StartsWith(WhiteListedNamespace, StringComparison.InvariantCulture))
                            ls.Add(tdef.FullName);
                    }
                if (ls.Count > 0)
                    throw (new TypeNotAllowedException(ls.ToArray()));
            }
        }
