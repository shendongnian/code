    using UnityEngine;
    public class CharacterInstantiation : OnJoinedInstantiate {
    public delegate void OnCharacterInstantiated(GameObject character);
    public static event OnCharacterInstantiated CharacterInstantiated;
    public int counter = 0;
    public Vector3[] spawnPositions;
    public new void OnJoinedRoom() {
        if (this.PrefabsToInstantiate != null) {
            GameObject o = PrefabsToInstantiate[(PhotonNetwork.player.ID - 1) % 4];
            //Debug.Log("Instantiating: " + o.name);
            Vector3 spawnPos = Vector3.zero;
            if (this.SpawnPosition != null) {
                spawnPos = this.SpawnPosition.position;
            }
            Vector3 random = Random.insideUnitSphere;
            random = this.PositionOffset * random.normalized;
            spawnPos += random;
            spawnPos.y = 0;
            Camera.main.transform.position += spawnPos;
            o = PhotonNetwork.Instantiate(o.name, spawnPositions[counter], Quaternion.identity, 0);
            if (CharacterInstantiated != null) {
                CharacterInstantiated(o);
                counter++;
            }
        }
    }
