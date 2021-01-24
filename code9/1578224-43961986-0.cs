        public List<string> noDup(List<string> myList)
            {
                var convert = myList.ConvertAll(i => i.ToLower());
                List<string> remove = convertLower.Distinct().ToList();
                return remove;
            }
    
        public void length(List<string> myList)
        {
            int i = int.Parse(lengthSearch.Text);
            List<string> temp = new List<string>();
    
            foreach(string item in myList)
            {
                if(item.Length == i)
                {
                    temp.Add(item);
                }
            }
            searchResult.Text = string.Join(",", temp);
        }
    
            private void button_Click(object sender, EventArgs e)
            {   
                var remove = noDup(yourInputList);
                length(remove);
            }
