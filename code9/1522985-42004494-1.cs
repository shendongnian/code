    public class Solider : Human {
         IEnumerable<IWeapons> _allAvailableWeapons;
         IWeapon _selectedWeapon;
         public Soldier(IEnumerable<IWeapon> weapons)
        {
            _allAvailableWeapons = weapons;
            // some conditions
            // Select the correct weapon for this soldier
            _selectedWeapon = _allAvailableWeapons.Single(x => x.Id == "Something");
        }    
    }
    public class Civilian : Human
    {
         public Civilian()
         {
         }
    }
