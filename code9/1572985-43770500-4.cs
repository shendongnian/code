    public class foo {
        public delegate void UpdateCallback(string msg);
        private UpdateCallback _ucb;
        public foo(UpdateCallback cb){
            _ucb = cb;
        }
        private void test(){
            if(_ucb != null) {
               _ucb("Message Here");
            }
        }
    }
    public partial class GUI : Form {
         
         public GUI(){
               InitializeComponent();
               foo fooinstance = new foo(showmessage);
         }
         private void showmessage(string msg){
               //do whatever with the message
         }
    }
