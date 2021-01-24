    public partial class GUI : Form {
         foo fooinstance = new foo();
         
         public GUI(){
               InitializeComponent();
               fooinstance.PropertyChanged += doEvent;
         }
         private void doEvent(object sender, PropertyChangedEventArgs e){
            foo updated = sender as foo;
            if (object.ReferenceEquals(e.PropertyName, "changed int")) {
                ShowWhatChanged(updated.bar); //show on GUI
            }
         }
