    public abstract class BaseConnection<T>
	{
        protected T _stream;
		protected TcpClient _client;
        public abstract void Connect();
		public abstract void Disconnect();
	}
    public class Connection<T> : BaseConnection<T> 
        where T: Stream 
    {
        public override void Connect(){/*Do somthing*/}
        public override void Disconnect(){/*Do somthing*/}
        public void Reconnect()
		{
			Disconnect();
			Connect();
		}
    }
