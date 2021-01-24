        static void Main()
        {
            
            //DECLARE INTERNET EXPLORER OBJECT
            SHDocVw.InternetExplorer m_autologinIEWindow = new SHDocVw.InternetExplorer();
    
            //ASSOCIATE HANDLER TO DOCUMENT COMPLETE EVENT
            m_autologinIEWindow.DocumentComplete += URLAutologinDocumentCompleteEventHandler;
    
            //NAVIGATE THE URL
            m_autologinIEWindow.Navigate("about:blank");
            m_autologinIEWindow.AddressBar = true;
            m_autologinIEWindow.Visible = true;
        
        }
            
        //HANDLER DEFINITION
        public static void URLAutologinDocumentCompleteEventHandler(object senderObject, ref object objectTwo /* not sure what this argument is for */)
        {
            //Something
        }
      
