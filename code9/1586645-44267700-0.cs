    public class A
    virtual method1(bool callInsideMethod = true){
     // 100 lines of code
     if(callInsideMethod)
         insideMethod1();
    }
    
    public class B : A
    override method1(bool callInsideMethod = false){
    // call the 100 lines of code but ignore calling insideMethod1()
    }
