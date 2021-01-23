	public class UIPlayerCharacterData : PlayerCharacterData {
		PlayerCharacterData playerCharacterData;
	    public void NameToCharacterDataUI() {
	       Text_ch_sh_char_name_string.text = GetPlayerCharacterData().characterName;
	   }
	   // etc, more functions like that x50-70    
	   void Awake () {
	      PlayerCharacterData playerCharacterData = GetCharacterData();
	      NameToCharacterDataUI();
	      // etc, calling more functions x50-70 
	   }
	   PlayerCharacterData GetPlayerCharacterData() {
	       if (playerCharacterData == null) {
	           playerCharacterData = GameObject.FindGameObjectWithTag("CharacterData").GetComponent<PlayerCharacterData>();
	       }
	       return playerCharacterData;
	   }
	}
