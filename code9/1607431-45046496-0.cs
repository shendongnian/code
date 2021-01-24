    public interface IWeapon
    {
        void Attack();
    }
    public interface IRangedWeapon
    {
        bool IsInRange(ITargetable target);
    }
    public interface IRequiresAmmunition
    {
        void Reload();
        int  AmmoRemaining { get; set; }
    }
    public class Sword : IWeapon
    {
        public virtual void Attack() { //code }
    }
    public class Rifle : IWeapon, IRequiresAmmunition, IRangedWeapon
    {
        public virtual void Attack() { //code }
        public virtual void Reload() { //code }
        public virtual int  AmmoRemaining { get { } set { } }
        public virtual bool IsInrange (ITargetable target) { //code }
    }
    public class LaserGun: IWeapon, IRangedWeapon
    {
        public virtual void Attack() { //code }
        public virtual bool IsInrange (ITargetable target) { //code }
    }
    public class WeaponController
    {
       private List<IWeapon> someWeapons;
       private IWeapon aWeapon;
       public void Weapon_OnUse()
       {
           if (this.IsInMeleeRange(currentTarget))
           {
               aWeapon.Attack();
               return;
           }
           var w = aWeapon as IRangedWeapon;
            
           if (w != null && w.IsInRange(currentTarget)
           {
               aWeapon.Attack();
               return;
           }
           context.HUD.Warn("Out of range");
       }
       public void Weapon_OnReload()
       {
           var w = aWeapon as IRequiresAmmunition;
           if (w != null) 
           {
                w.Reload();
                context.HUD.DisplayAmmo(w.AmmoRemaining);
           }
       }
    }
