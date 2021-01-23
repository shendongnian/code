    class A {
          List<A_B> A_Bs {get;set;}
        }
    
        class A_B {
          int AId {get;set;}
          A MyA {get;set;}
          int BId {get;set;}
          B MyB {get;set;}
        }
    class B {
        List<A_B> A_Bs {get;set;}
    }
