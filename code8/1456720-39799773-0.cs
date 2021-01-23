       static void Main(string[] args) { 
           try{
           Console.WriteLine("First Name is " + args[0]);
    
            Console.WriteLine("Last Name is " + args[1]);
    
            Console.ReadLine();
       }catch (OutOfBoundsException exception){
         MessageBox.Show("Insufficient input parameters");
       }
