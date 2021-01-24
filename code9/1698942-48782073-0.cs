    class MyContainerIsNotPartOfTheQuestion
    {
        private bool m_FirstSet;
        public bool FirstSet
        {
            get { return m_FirstSet; }
            set
            {
                if (value != m_FirstSet)
                {
                    m_FirstSet = value;
                    // handle On/Off where it belongs
                    if (value) On1();
                    else Off1();
                }
            }
        }
    
        // same for SecondSet etc.
    
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // ... your starting code
    
            FirstSet = int.Parse(json[0].Value) != 0;
            // set others
    
            // Done, no handling of On/Off here
        }
    }
