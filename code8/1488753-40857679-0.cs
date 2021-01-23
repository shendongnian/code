    public class Button(){
        private Action _onClick;
    
        public Button(Action onClick){
            _onClick = onClick;
        }
        
        //Other method that calls _onClick()
    }
    
    //Other Class
    Button b = new Button(() => {/*Do Code Here*/});
