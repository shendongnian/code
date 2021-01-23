    namespace DELEGATESAMPLEPROJECT
    {
      public class Program
      {
        public delegate void OnConfirmCall();
        public OnConfirmCall confirmCall;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var programRef = new Program().getReference(); // <- only one reference.
            Application.Run(new Form1(programRef)); //Start the form1
            programRef.startFunctionCall();//Call this function to change the Label in Form1
        }
        public Program getReference(){
            return this;
        }
        public void startFunctionCall(){
            Console.WriteLine("Function Call Started!"); //Write this to confirm the function is called
            if(confirmCall != null){
                Console.WriteLine("Function Call Executing...");//Write this to confirm that the delegate is working
                confirmCall();
            }
        }
    }
