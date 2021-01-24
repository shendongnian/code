        public int Compare(string a)
        {
            string[] arr = a.Split('/');
            return int.Parse(arr[1] + arr[0]);
        }
