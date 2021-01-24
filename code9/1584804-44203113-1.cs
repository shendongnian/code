    public class Bar
    {
        public void DoAllTheThings()
        {
            var foo = new Foo();
            foo.EndOfVideo += foo_EndOfVideo;
        }
        void foo_EndOfVideo(object sender, EventArgs e)
        {
            Console.WriteLine("EndOfVideo");
        }
    }
