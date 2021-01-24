    public class Model
    {
        private static int m_Counter = 0;
		//
		public static ResetCounter(int start)
		{
			m_Counter=start;
		}
        public int Id { get; set; }
        public Model()
        {
            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
        }
    }
