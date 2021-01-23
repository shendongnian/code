    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
	class Program
	{
		public static void Main(string[] args)
		{
			Character1Class character = new Character1Class("Zoltan the Powerful");
			SwordClass sword = new SwordClass("Holy Avenger");
			character.Equip(sword);
			character.Attack();
			Console.ReadKey();
		}
		public interface ICharacters
		{
			// The name of the character
			string sCharacterName { get; set; }
			void Equip(IWeapon weapon);
		}
		public interface IWeapon
		{
			// The name of the weapon
			string sWeaponName { get; set; }
			int Attack();
		}
		public class Character1Class : ICharacters
		{
			// The name of the character
			public string sCharacterName { get; set; }
			public Character1Class(string charName)
			{
				sCharacterName = charName;
			}
			public void Equip(IWeapon weapon)
			{
				MyWeapon = weapon;
				Console.WriteLine(sCharacterName + " equiped " + weapon.sWeaponName + ".");
			}
			public IWeapon MyWeapon { get; set; }
			public void Attack()
			{
				if (MyWeapon == null)
				{
					Console.WriteLine(sCharacterName + " punches for 1 pt of damage.");
				}
				else
				{
					Console.WriteLine(string.Format("{0} swings for {1} pt of damage.", sCharacterName, MyWeapon.Attack()));
				}
			}
		}
		public class SwordClass : IWeapon
		{
			// The name of the weapon
			public string sWeaponName { get; set; }
			public SwordClass(string sName)
			{
				sWeaponName = sName;
			}
			public int Attack()
			{
				return 50;
			}
		}
	}
}
