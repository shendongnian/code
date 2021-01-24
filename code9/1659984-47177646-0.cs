    public class MyProgress<T> : IProgress<T>
    {
        public event ProgressChangedEventHandler<T> ProgressChanged;
        public void Report(T value)
        {
            ProgressChanged?.Invoke(this, value);
        }
    }
    public delegate void ProgressChangedEventHandler<T>(object sender, T progress);
