    interface IWeapon { }
    interface IGun : IWeapon
    {
        Magazine Magazine { get; set; }
    }
    interface IWeaponComponent
    {
        Attach(IWeapon weapon);
    }
    public class Gun : Weapon, IGun
    {
        public Magazine Magazine { get; set; }
    }
    public class Magazine : IWeaponComponent
    {
        public Attach(IWeapon weapon)
        {
            IGun gun = weapon as IGun;
            if (gun == null)
            {
                throw new ArgumentException("Cannot attach a magazine to weapon that is not a gun");
            }
            gun.Magazine = this;
        }
    }
