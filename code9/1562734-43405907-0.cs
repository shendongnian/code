    public class Displayer
    {
        private string[] _lines;
        public string[] Lines
        {
            get { return _lines; }
            set
            {
                // while setting new value call Update
                _lines = value;
                Update();
            }
        }
        public async void Update()
        {
            // update console only once
            Console.Clear();
            foreach (string s in Lines)
            {
                Console.WriteLine(s);
            }
        }
    }
