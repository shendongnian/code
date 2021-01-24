    class FloatArr : IList<float>
    {
        //(snip)
        // p and hArr's decliration and assignment
        //(snip)
        public float this[int index]
        {
            get
            {
                unsafe
                {
                    float* p = (float*)hArr.ToPointer();
                    return *(p + i);
                }
            }
            set
            {
                unsafe
                {
                    float* p = (float*)hArr.ToPointer();
                    *(p + i) = value;
                }
            }
        }
        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        void ICollection<float>.Add(float item)
        {
            throw new NotImplementedException();
        }
        void ICollection<float>.Clear()
        {
            throw new NotImplementedException();
        }
        bool ICollection<float>.Contains(float item)
        {
            throw new NotImplementedException();
        }
        void ICollection<float>.CopyTo(float[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        bool ICollection<float>.Remove(float item)
        {
            throw new NotImplementedException();
        }
        int ICollection<float>.Count
        {
            get { throw new NotImplementedException(); }
        }
        bool ICollection<float>.IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        int IList<float>.IndexOf(float item)
        {
            throw new NotImplementedException();
        }
        void IList<float>.Insert(int index, float item)
        {
            throw new NotImplementedException();
        }
        void IList<float>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
