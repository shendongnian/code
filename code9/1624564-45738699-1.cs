    public class CharacterController : MonoBehaviour
    {
       //edit: playField is not supposed hold value, just to get
       //access to a method in PlayField
       PlayField playField; 
       FieldData fData;           
       void Start(){
           playField = new PlayField();
           InitArray(playField,30,30);
           fData = new FieldData();
       }
      void InitArray(PlayField playfield int x, int y){
           playfield.SingleField = new SingleField[x,y];
           for (int j =0; j< y;.. {
                for (int i..  {
                    playfield.singleField[x,y] = new SingleField();
                }
           }
      }
       void Update(){
          fData = playField.GetFieldData(5,6); //We're just telling it go to that method 
       } 
    }
