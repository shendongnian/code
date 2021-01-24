    private class Test
    {
        readonly Random Rnd = new Random();
        private List<string> _titles = new List<string>(); // Init the list with 0 elements, it will be filled-in on the first call to `GetRandomTip`
        private string GetRandomTip()
        {
            // fill the list if it's empty
            if(_titles.Count == 0) 
            {
                _titles = new List<string>
                {
                    "You can copy the result by clicking over it",
                    "Remember to press Ctrl + Z if you messed up",
                    "Check web.com to update the app"
                };
            }
            int index = Rnd.Next(0, _titles.Count);
            string randomString = _titles[index];
            _titles.RemoveAt(index);
            return randomString;
        }
    }
