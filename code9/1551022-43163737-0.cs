        class TestDataReader : IDataReader {
            int[] firsts = { 1, 2, 3, 4 };
            string[] seconds = { "abc", "def", "ghi" };
            byte[] thirds = { 0x30, 0x31, 0x32 };
            // The data types of each column.
            Type[] dataTypes = { typeof(int), typeof(string), typeof(byte) };
            // The names of each column.
            string[] names = { "firsts", "seconds", "thirds" };
            // This function uses coroutines to turn the "push" approach into a "pull" approach.
            private IEnumerable<object[]> GetRows() {
                // Just re-use the same array. 
                object[] row = new object[3];
                foreach (var f in firsts) {
                    foreach (var s in seconds) {
                        foreach (var t in thirds) {
                            row[0] = f;
                            row[1] = s;
                            row[2] = t;
                            yield return row;
                        }
                    }
                    // here I also bulk load he table and clear it
                }
            }
            // Everything below basically wraps this.
            IEnumerator<object[]> rowProvider;
            public TestDataReader() {
                rowProvider = GetRows().GetEnumerator();
            }
            public object this[int i] {
                get {
                    return GetValue(i);
                }
            }
            public object this[string name] {
                get {
                    return GetValue(GetOrdinal(name));
                }
            }
        
            public int  Depth                       { get { return 0;                               } }
            public int  FieldCount                  { get { return dataTypes.Length;                } }
            public bool IsClosed                    { get { return false;                           } }
            public int  RecordsAffected             { get { return 0;                               } }
            // These don't really do anything.
            public void Close()                     { Dispose();                                    }
            public void Dispose()                   { rowProvider.Dispose();                        }
            public string   GetDataTypeName(int i)  { return dataTypes[i].Name;                     }
            public Type     GetFieldType(int i)     { return dataTypes[i];                          }
            // These functions get basic data types.
            public bool     GetBoolean(int i)       { return (bool)     rowProvider.Current[i];     }
            public byte     GetByte(int i)          { return (byte)     rowProvider.Current[i];     }
            public char     GetChar(int i)          { return (char)     rowProvider.Current[i];     }
            public DateTime GetDateTime(int i)      { return (DateTime) rowProvider.Current[i];     }
            public decimal  GetDecimal(int i)       { return (decimal)  rowProvider.Current[i];     }
            public double   GetDouble(int i)        { return (double)   rowProvider.Current[i];     }
            public float    GetFloat(int i)         { return (float)    rowProvider.Current[i];     }
            public Guid     GetGuid(int i)          { return (Guid)     rowProvider.Current[i];     }
            public short    GetInt16(int i)         { return (short)    rowProvider.Current[i];     }
            public int      GetInt32(int i)         { return (int)      rowProvider.Current[i];     }
            public long     GetInt64(int i)         { return (long)     rowProvider.Current[i];     }
            public string   GetString(int i)        { return (string)   rowProvider.Current[i];     }
            public object   GetValue(int i)         { return (object)   rowProvider.Current[i];     }
            public string   GetName(int i)          { return names[i];                              }
            public bool IsDBNull(int i) {
                object obj = rowProvider.Current[i];
                return obj == null || obj is DBNull;
            }
            // Looks up a field number given its name.
            public int GetOrdinal(string name) {
                return Array.FindIndex(names, x => x.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            // Populate "values" given the current row of data.
            public int GetValues(object[] values) {
                if (values == null) {
                    return 0;
                } else {
                    int len = Math.Min(values.Length, rowProvider.Current.Length);
                    Array.Copy(rowProvider.Current, values, len);
                    return len;
                }
            }
            // This reader only supports a single result set.
            public bool NextResult() {
                return false;
            }
            // Move to the next row.
            public bool Read() {
                return rowProvider.MoveNext();
            }
            // Don't bother implementing these in any meaningful way.
            public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }
            public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) {
                throw new NotImplementedException();
            }
            public IDataReader GetData(int i) {
                throw new NotImplementedException();
            }
            public DataTable GetSchemaTable() {
                return null;
            }
        }
