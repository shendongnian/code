    interface IHandle<T>
        {
            T Handle { get; set; }
        }
        public interface Message<T>
        {
            T Payload { get; set; }
        }
        
        public class MyViewModel <T>: IHandle<T>
        {
            public T Handle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }
