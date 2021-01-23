            void clock_tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
            foreach(Record record in record_list)
            {
                record.EvtTimeString = DateTime.Now.ToString();
            }
            record_list.ResetBindings();
        }
