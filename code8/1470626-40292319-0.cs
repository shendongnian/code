        int c = 0;	//Just to go the first time
	    //We create an index to compare the former with the "actual"     
        //log in every loop of the "foreach"
            String IndiceDestin0 = string.Empty;
            String IndiceLat0 = string.Empty;
            String IndiceLong0 = string.Empty;
            String IndiceDestin1;
            String IndiceLat1;
            String IndiceLong1;          
            foreach (String log in logslogs)
            {
                String[] LongContent = log.Split(',');
                Loglog log = new Loglog();
                log.Destin = LongContent[0];
                log.Lat = Convert.ToChar(LongContent[1]);
                log.Long = LongContent[2];                
                log.Barcode = LongContent[6];
                log.Source = LongContent[7];
                log.DestDestinBarcode = LongContent[8];
                log.SampleName = LongContent[9];                
                AllLogs.Add(log);
                //This only works once, the first time because we don't have a "former" data to compare we have to bypass the comparison
                if (c == 0)	
                {
                    IndiceDestin0 = LongContent[0];
                    IndiceLat0 = LongContent[1];
                    IndiceLong0 = LongContent[2];
                    c++;
                }
                else
                {
                    IndiceDestin1 = LongContent[0];
                    IndiceLat1 = LongContent[1];
                    IndiceLong1 = LongContent[2];
                    if (IndiceDestin0.Equals(IndiceDestin1) && IndiceLat0.Equals(IndiceLat1) && IndiceLong0.Equals(IndiceLong1))
                    {                        
                        int last = logsToButtons.Count - 1;
                        string oldLog = logsToButtons[last].ToString();
                        string appendedLog = oldLog + log;
                        //We remove the last "single" log to add the aggregated log
                        logsToButtons.RemoveAt(last);
                       
                        logsToButtons.Add(appendedLog);                        
                    }
                    else
                    {
                        logsToButtons.Add(log);
                    }
                    IndiceDestin0 = IndiceDestin1;
                    IndiceLat0 = IndiceLat1;
                    IndiceLong0 = IndiceLong1;
                    c++;
                }                               
                
            }
