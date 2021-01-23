	public abstract class Character
	{
		public float m_Health { get; protected set; }
		protected abstract float DefaultHealth { get; }
		void Awake()
		{
			m_Health = DefaultHealth;
		}
	}
	public class Enemy : Character
	{
		protected override float DefaultHealth { get { return 10; } }
	}
