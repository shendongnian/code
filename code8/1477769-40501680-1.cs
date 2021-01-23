    public class Track<T> {
        ...    
        // No "<T>" declaration here, uses "T" from Track<T>
        public void AddKey(float time, T value) {
            ...
        }
    }
