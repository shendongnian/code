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
           playfield.singleField = new SingleField[x,y];
           for (int j =0; j< y;.. {
                for (int i..  {
                    playfield.singleField[x,y] = new SingleField();
                    playfield.singleField[x,y].fieldData = new FieldData();
                }
           }
      }
       void Update(){
          //The return was not supposed to be a field in this instance of
          //PlayField, but come from the PlayField class itself as 
          //this.singleField[x,y] (a array in PlayField)
          fData = playField.GetFieldData(5,6); //We're just telling it go to that method 
       } 
    }
    public class PlayField
    {
        public SingleField[,] singleField = new SingleField[30,30];//evrything initailized and so on in the rest of the class here ommited. ect.
        
        public FieldData GetFieldData(int x,int y){
             //Here was the catch. Return values form this Class
             // and not read from the instance created in CharacterController
             //was giving me a nullrefence while I was using only FieldData
             return this.singleField[x,y].fieldData;
        }
    }
