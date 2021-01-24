    class FloatArr : IReadOnlyList<float>
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
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        int IReadOnlyCollection<float>.Count
        {
            get { throw new NotImplementedException(); }
        }
    }
