    namespace APVariable
    {
        public class Variables : IEnumerable, IEnumerator
        {
            private Collection<Variable> mCol;
            public Variable Add(string Name, object Value, string skey = "")
            {
                Variable objNewMember = new Variable();
                objNewMember.Name = Name;
                objNewMember.Value = Value;
    
                if (skey.Length == 0)
                {
                    mCol.Add(objNewMember);
                }
                else
                {
                    try
                    {
                        Information.Err().Clear();
                        mCol.Add(objNewMember, skey);
                        if (Information.Err().Number != 0)
                        {
                            Information.Err().Clear();
                            mCol.Add(objNewMember);
                        }
                    }
                    catch { Information.Err(); }
                    {
    
                    }
                }
                return objNewMember;
                objNewMember = null;
            }
            public int count
            {
                get
                {
                    return mCol.Count;
                }
            }
            //public void Remove(int vntIndexKey)
            //{
            //    //this can be the int or the string.
            //    //passes the index or the key of the collection to be removed.
    
            //    mCol.Remove(vntIndexKey);
            //}
            public void Remove(dynamic vntIndexKey)
            {
                //this can be the int or the string.
                //passes the index or the key of the collection to be removed.
    
                mCol.Remove(vntIndexKey);
            }
            public dynamic newEnum
            {
                get
                {
                    return mCol.GetEnumerator();
                }
    
            }
    
            public Variable this[object vIndex]
            {
                get
                {
                    Variable result = null;
                    try
                    {
                        result = (Variable)mCol[vIndex];
    
                    }
                    catch
                    {
                    }
                    return result;
                }
            }
            public IEnumerator GetEnumerator()
            {
                //this property allows you to enumerate
                //this collection with the For...Each syntax
                return mCol.GetEnumerator();
            }
            public Variables()
            {
                mCol = new Collection<Variable>();
            }
             ~Variables()
            {
                mCol = null;
    
            }
    
        }
    }
    </code>
    </pre>
