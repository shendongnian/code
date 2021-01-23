        private void m_getInstrDetails(Instrument instr)
        {
            m_ContractName = instr.Name.ToString();
            m_type = instr.Product.Type.ToString();
            m_prod = instr.Product.ToString();
            m_SmallestTickIncrtement = instr.InstrumentDetails.SmallestTickIncrement;
        
            if(InstrumentDetails.ExpirationDate != null)
            {
              //if you change the .Month, .Day, and .Year to int, and test against
              //ExpirationDate, this will work fine                        
              //month calc
              int month = m_instr.InstrumentDetails.ExpirationDate.Month; 
              int day = m_instr.InstrumentDetails.ExpirationDate.Day;
              int year = m_instr.InstrumentDetails.ExpirationDate.Year;
               m_expDate1 = new DateTime(year, month, day);
             }
        }
