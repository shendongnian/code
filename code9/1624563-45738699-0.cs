    public class CharacterController : MonoBehaviour
    {
       //edit: playField is not supposed hold value, just to get
       //access to a method in PlayField
       PlayField playField; 
       FieldData fData;           
       void Start(){
           playField = new PlayField();
           playField.InitArray(playField,30,30);
           fData = new FieldData();
       }
       void Update(){
          fData = playField.GetFieldData(5,6); //We're just telling it go to that method 
       } 
    }
