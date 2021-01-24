	public class Person
	{
		public int Attack { get; private set; }
		public int Health { get; private set; }
		public Person(int attack, int health)
		{
			Attack = attack;
			Health = health;
		}
		public void AttackAction(int attack)
		{
			Health -= attack;
		}
	}
	public class Hero : Person
	{
		public Hero(int attack, int health)
			:base (attack , health)
		{
		}
	}
	public class Enemy : Person
	{
		public Enemy(int attack, int health)
			:base (attack , health)
		{
		}
	}
