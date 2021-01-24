    public class AScript : MotherBall {
        public new void Setting(){
          //Do something
        }
    }
 
    var _ball = new AScript();
    _ball.Setting() // calls Setting on AScript
    ((MotherBall) _ball).Setting(); // Calls Setting on MotherBall
