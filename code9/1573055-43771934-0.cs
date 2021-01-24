        private void button1_Click(object sender, EventArgs e)
        {
            foreach(string folder in checkedListBox1.CheckedItems)
            {
                System.Reflection.MethodInfo mi = this.GetType().GetMethod(folder, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(this, null);
                }
            }
        }
        private void cat()
        {
            Console.WriteLine("cat");
        }
        private void dog()
        {
            Console.WriteLine("dog");
        }
        private void fish()
        {
            Console.WriteLine("fish");
        }
