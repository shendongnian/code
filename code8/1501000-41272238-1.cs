    public partial class Form1 : Form {
    
       // We need this because this will allow us to interact with UI controls. UI controls can only be accessed by the thread that 
       // created the UI control. In this case it is the thread which started the application so the main thread.
       private readonly SynchronizationContext synchronizationContext;
       private DateTime previousTime = DateTime.Now;
    
       public Form1() {
          InitializeComponent();
          synchronizationContext = SynchronizationContext.Current;
       }
    
       private void Stop_Click(object sender, EventArgs e) {
             
          // I am the UI thread. I can do this because T2 is helping me do the loop.
          MessageBox.Show( "I am doing other things." );
       }
    
       private async void ButtonClickHandlerAsync(object sender, EventArgs e) {
          button1.Enabled = false;
          var count = 0;
    
          // I am the UI thread. I have other things to do. So please run this loop by using a thread from the thread pool.
          // When you are done running the loop let me know (This is what the await does)
          // I am the UI thread so I am going to return back from right here
          // to the point where ButtonClickHandlerAsync was called from. (it was called by a click, so when it returns it will have nothing
          // to do. Therefore, it will be ready to react to another UI job such as another click or update the UI etc.
          await Task.Run( () =>
          {
             // I am a thread from the thread pool. My name is T2. I am helping the UI thread so the UI thread can do other things.
             for( var i = 0; i <= 5000000; i++ ) {
                UpdateUI( i );
                count = i;
             }
          } );
    
            
          // I am the UI thread. Ok looks like the loop is done. So I will do the following 2 lines of work
          label1.Text = @"Counter " + count;
          button1.Enabled = true;
       }
    
       public void UpdateUI(int value) {
    
          // I am T2. I am helping the UI thread.
          var timeNow = DateTime.Now;
    
          if( ( DateTime.Now - previousTime ).Milliseconds <= 50 )
             return;
    
          // I do not have access to the UI controls since I did not create them. So I am just going to ask the synchronizationContext
          // to do this for me by giving it a SendOrPostCallback
          synchronizationContext.Post( new SendOrPostCallback( o =>
          {
             // I am the UI thread. I will do this.
             label1.Text = @"Counter " + ( int ) o;
          } ), value );
    
          // I am T2. I will do this and then return and do more work.
          previousTime = timeNow;
       }
