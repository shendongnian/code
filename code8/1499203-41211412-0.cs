        private void button1_Click(object sender, EventArgs e)
        {
            Things t1 = new Things();
            t1.Item = "z";
            Things t2 = new Things();
            t2.Item = "a";
            Things[] things = new Things[]{ t1, t2};
            Array.Sort(things, CompareThings);
            foreach(Things t in things)
            {
                Console.WriteLine(t.Item);
            }
        }
        private int CompareThings(Things c1, Things c2)
        {
            return c1.Item.CompareTo(c2.Item);
        }
