    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class JsonTest : MonoBehaviour
    {
    	[Serializable]
    	public class Ability
    	{
    		public int baseId;
    		public string name;
    
    		public Ability(int _baseId, string _name) 
    		{
    			baseId = _baseId;
    			name = _name;
    		}
    	}
    
    	public class Abilities
    	{
    		public List<Ability> baseAbilities;
    
    		public Abilities(List<Ability> _baseAbilities)
    		{
    			baseAbilities = _baseAbilities;
    		}
    	}
    
    	void Start()
    	{
    		List<Ability> list = new List<Ability>();
    		list.Add(new Ability(1, "Focused Elemental Strike"));
    		list.Add(new Ability(2, "Another ability"));
    
    		Abilities baseAbilities = new Abilities(list);
    
    		string serializedAbilites = JsonUtility.ToJson(baseAbilities);
    
    		Debug.Log(serializedAbilites);
    
    		Abilities deserializedAbilites = JsonUtility.FromJson<Abilities>(serializedAbilites);
    	}
    }
