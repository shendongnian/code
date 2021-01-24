    using UnityEngine;
    using System.Collections.Generic;
    using System;//Included to use Type and [Serializable]
    
    public class Items : MonoBehaviour
    {
        public struct SerializedObject //struct to hold the type of the object and the json string
        {
            public Type type;
            public string json;
        }
    
        static Dictionary<int, SerializedObject> items = new Dictionary<int, SerializedObject>();//dictionary must hold both type and json string to be used with JsonUtility
    
        private static bool initialized;
    
        [SerializeField]
        Texture2D[] itemIcons;
    
        private void Start()
        {
            Gun desertEagle = new Gun();
            desertEagle.damage = 40;
            desertEagle.range = 20;
            desertEagle.maxAmmunition = 7;
            desertEagle.firemode = FireMode.Semi;
            desertEagle.firerate = 1;
    
            desertEagle.name = "Desert Eagle";
            desertEagle.description = "Desert Eagle (.50 Cal) is a semi-automatic pistol with an ammo capacity of 7 rounds";
            desertEagle.equippable = true;
            desertEagle.icon = itemIcons[1];
    
    
            Consumable donut = new Consumable();
            donut.food = 30;
    
            donut.name = "Donut";
            donut.description = "A ring full of legendary awesomeness";
            donut.equippable = true;
            donut.icon = itemIcons[2];
    
            Consumable coffee = new Consumable();
            coffee.water = 30;
            coffee.stamina = 50;
    
            coffee.name = "Coffee";
            coffee.description = "A delicious beverage to help you get up in the morning. Goes well with donuts.";
            coffee.equippable = true;
            coffee.icon = itemIcons[3];
    
            //For each object store the Type and serialize the data using JsonUtility
            SerializedObject so_desertEagle;
            so_desertEagle.type = desertEagle.GetType();
            so_desertEagle.json = JsonUtility.ToJson(desertEagle);
            SerializedObject so_donut;
            so_donut.type = donut.GetType();
            so_donut.json = JsonUtility.ToJson(donut);
            SerializedObject so_coffee;
            so_coffee.type = coffee.GetType();
            so_coffee.json = JsonUtility.ToJson(coffee);
            RegisterItem(1, so_desertEagle);
            RegisterItem(2, so_donut);
            RegisterItem(3, so_coffee);
            /*//Made this for testing 
            Item gunCopy = GetItem(1);
            Gun desertEagle2 = (Gun) gunCopy;
            desertEagle2.ammunition--;
    
            Debug.Log(desertEagle.ammunition + " / " + desertEagle2.ammunition);
            //Debug result is "1 / 0"
            */
            initialized = true;
        }
    
        public static void RegisterItem(int id, SerializedObject item)
        {
            items.Add(id, item);
        }
    
        public static void UnregisterItem(int id)
        {
            items.Remove(id);
        }
    
        
    
        public static Item GetItem(int id)
        {
            return (Item) JsonUtility.FromJson(items[id].json, items[id].type); //Use JsonUtility to create a copy of the serialized object
        }
    }
    
    [Serializable]
    public class ItemStack
    {
    
        Item item;
        int amount;
        int max = 10;
    
        public void Add(int amount)
        {
            if (item.stackable && this.amount + amount <= max) this.amount += amount;
            else if (item.stackable) this.amount = max;
        }
    
        public void Remove(int amount)
        {
            if (item.stackable) this.amount -= amount;
        }
    }
    
    [Serializable]//JsonUtility only works with [Serializable] objects
    public class Item
    {
        public string name = "Item";
        public string description = "Your everyday standard item.";
        public bool equippable = false;
        public bool stackable = true;
        public Mesh model; //I would recommend storing the meshes in another dictionary and setting a reference here
        public Texture2D icon;
    }
    
    [Serializable]
    public class Weapon : Item
    {
        public float damage = 5;
        public float range = 1;
    }
    
    [Serializable]
    public class Gun : Weapon
    {
        public int ammunition = 1;
        public int maxAmmunition = 1;
        public FireMode firemode = FireMode.Semi;
        public int firerate = 1;
        public new float range = 10;
    }
    
    [Serializable]
    public enum FireMode
    {
        Semi,
        Automatic,
        Burst
    }
    
    [Serializable]
    public class Consumable : Item
    {
        public float food;
        public float water;
        public float health;
        public float stamina;
    }
