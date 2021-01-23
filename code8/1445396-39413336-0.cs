        public abstract class TextBoxBase
        {
            public abstract object GetMin();
            public abstract object GetMax();
            public abstract object GetValue();
        }
        public abstract class TextBox<T> : TextBoxBase
        {
            public T min { get; set; }
            public T max { get; set; }
            public T value { get; set; }
            public virtual void SetTextBox(T mn, T mx, T val)
            {
                min = mn;
                max = mx;
                value = val;
            }
            public override object GetMin() { return min; }
            public override object GetMax() { return max; }
            public override object GetValue() { return value; }
        }
        public class TextBoxInt : TextBox<int>
        {
            public override void SetTextBox(int mn, int mx, int val)
            {
                min = mn;
                max = mx;
                value = val;
            }
        }
        public class TextBoxFloat : TextBox<float>
        {
            public override void SetTextBox(float mn, float mx, float val)
            {
                min = mn;
                max = mx;
                value = val;
            }
        }
