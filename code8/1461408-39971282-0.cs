    static void Main()
    {
        classA obA = new classA();
        classB obB = new classB();
        obA.Shown += ( object sender, EventArgs e ) => { obB.ShowB(); };
        obA.ShowA();
    }
    public class classA
    {
        public event EventHandler Shown;
        public classA()
        {
        }
        public void ShowA()
        {
            Console.WriteLine( "I am class A" );
            if( Shown != null )
                Shown( this, EventArgs.Empty );
        }
    }
    public class classB
    {
        public event EventHandler Shown;
        public classB()
        {
        }
        public void ShowB()
        {
            Console.WriteLine( "I am class B" );
            if( Shown != null )
                Shown( this, EventArgs.Empty );
        }
    }
