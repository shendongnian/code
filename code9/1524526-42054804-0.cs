    class B : A {
    
        string copyMsg1 = msg1; <-- 1. assign non-static to non static 
        string copyMsg2 = msg2; <-- 2. assign static to non static
    
        string getMsg1 = alert1(); <-- 3. non static calling non-static
        string getMsg2 = alert2(); <-- 4. non static calling static
    
        void display() {
            msg1 = "";
            msg2 = "";
            alert2();           
        }
    }
