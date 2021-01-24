    // Unit.cs
    public class Unit : Component {
        // logic for your Unit Component
    }
    // Human.cs
    [RequireComponent(typeof (Unit))]
    public class Human : Component {
        Unit _parent;
        public void Initialize(){
            _parent = (Unit)GetComponentInParent(typeof(Unit));
        }
    }
    // Soldier.cs
    [RequireComponent(typeof (Human))]
    public class Soldier: Component {
        Human _parent;
        Weapon _meWeapon;
        public void Initialize(){
            _parent = (Human)GetComponentInParent(typeof(Human));
        }
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
