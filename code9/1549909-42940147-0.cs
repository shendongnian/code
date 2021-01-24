    public int GetInt(int i) {
        unsafe {
            var p = (int*)hArr.ToPointer();
            return *(p + i);
        }
    public void SetInt(int i, int val) {
        unsafe {
            var p = (int*)hArr.ToPointer();
            *(p + i) = val;
        }
    }
    public float GetFloat(int i) {
        unsafe {
            var p = (int*)hArr.ToPointer();
            return *(p + i);
        }
    public void SetFloat(int i, float val) {
        unsafe {
            var p = (float*)hArr.ToPointer();
            *(p + i) = val;
        }
    }
    ... // and so on
