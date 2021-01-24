    public class Unit : Component {
        // logic for your Unit Component
    }
    public class Human : Unit {
    }
    public class Soldier : Human {
        Weapon _weapon;
        public void AttachWeapon(Weapon wpn){
            _meWeapon = wpn;
        }
        public void DetachWeapon(){
            if(_meWeapon != null) {
                Destroy(_meWeapon);
                _meWeapon = null;
            }
        }
    }
