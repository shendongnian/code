       public class SetupWeaponsScript
        {
            [System.Serializable]
            public struct DirectedWeaponGroup
            {
                public DirectedWeaponScript[] weaponPrefabs;
            }
            // Here's our tuple combining a weapon prefab and a direction.
            [System.Serializable]
            public struct DirectedWeapon
            {
                public WeaponScript weapon;
                public WeaponScript.Direction direction;
            }
            // The prefabs array is now this tuple type.
            public DirectedWeaponGroup[] weaponGroups;
            public DirectedWeapon[] weaponPrefabs;
            public WeaponScript[] weapons;
            void Start()
            {
                weaponGroups = new DirectedWeaponScript[weaponGroups.Length];
                for (int h = 0; h <  weaponGroups.Length; h++)
                {
                    weaponPrefabs = weaponGroups[h].weaponPrefabs;
                    weaponPrefabs[h] = Instantiate<DirectedWeaponScript>(weaponGroups[h].weaponPrefabs);
                    weapons = new WeaponScript[weaponPrefabs.Length];
                    for (int i = 0; i < weaponPrefabs.Length; i++)
                    {
                        // Using typed Instantiate to save a GetComponent call.
                        weapons[i] = Instantiate<WeaponScript>(weaponPrefabs[i].weapon);
                        weapons[i].weaponDir = weaponPrefabs[i].direction;
                    }
                }
            }
