        public numToBin(object n)
        {
            assignType(n); //Check if the type is valid
            BigInteger r = new BigInteger(Convert.ToInt32(n)); //Make sure that the type is valid
            _arr = new List<bool>(); //Refresh the internal array of booleans
            while (r != 0) //While we arent left with 0...
            {
                //if (!first) if (_arr.Last()) r += 1; //If the last one was true, then add one, because we want the ceiling (round up not down)
                _arr.Add(!r.IsEven); //Add to the list
                r = r / 2; //Divide by two... I think this may potentially be 
            }
        }
