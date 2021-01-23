        private void button1_Click(object sender, EventArgs e)
        {
            Things t1 = new Things();
            t1.Item = "z";
            Things t2 = new Things();
            t2.Item = "a";
            Things[] things = new Things[]{ t1, t2};
            Array.Sort(things); // <-- the intenal implementation of CompareTo() we added to class Things will be used!
            foreach(Things t in things)
            {
                Console.WriteLine(t.Item);
            }
        }
