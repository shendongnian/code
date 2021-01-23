    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Game_Play : MonoBehaviour {
    
    	public int Num_Players = 11;
    	public int Players = 1;
    
    
    
    
    	// Use this for initialization
    	void Start () {
    	
    		//Section 1
    		//Create a list
    		// Using Character_Setup
    		//add 10 characters to list
    
    		List <Character_Setup> Characters = new List<Character_Setup> ();
    
    		Characters.Add (new Character_Setup ("Flamethrower"));
    		Characters.Add (new Character_Setup ("Shotgun"));
    		Characters.Add (new Character_Setup ("Rifle"));
    		Characters.Add (new Character_Setup ("Pistol"));
    		Characters.Add (new Character_Setup ("Machine Gun"));
    		Characters.Add (new Character_Setup ("Grenade Launcher"));
    		Characters.Add (new Character_Setup ("Knife"));
    		Characters.Add (new Character_Setup ("Rocket Launcher"));
    		Characters.Add (new Character_Setup ("Throwing Star"));
    		Characters.Add (new Character_Setup ("Sling Shot"));
    
    		foreach (Character_Setup character in Characters) {
    			print (character.Weapon);
    		}
    
    		//Section 2
    		// Create 2 teams Off 3 Players
    
    		// Team 1
    		//Create Blue Team
    		//use loop to fill team
    		//Create Variable to hold selection number
    		//Add to team
    		//Remove from Characters availble
    		List<Character_Setup> Blue_Team = new List<Character_Setup> ();
    		while (Blue_Team.Count < 3)
    		{
    			Character_Setup PlayerSelection = Characters [UnityEngine.Random.Range(0, Characters.Count)];
    			Blue_Team.Add (PlayerSelection);
    			Characters.Remove(PlayerSelection);
    		}
    
    		foreach (Character_Setup character in Blue_Team)
    		{
    			print (character.Weapon);
    		}
    
    		// Team 2
    		//Create Red Team
    		List<Character_Setup> Red_Team = new List<Character_Setup> ();
    		while (Red_Team.Count < 3)
    		{
    			Character_Setup PlayerSelection = Characters [UnityEngine.Random.Range (0, Characters.Count)];
    			Red_Team.Add (PlayerSelection);
    			Characters.Remove(PlayerSelection);
    		}
    
    		foreach (Character_Setup character in Red_Team)
    		{
    			print (character.Weapon);
    		}
    
    	}
