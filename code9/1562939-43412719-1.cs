    // When class is not specified, try PublicVars class
    using static testXyz.PublicVars;
    namespace testXyz {
      public partial class MainWindow : Window {
        ...
    
        // BuffOneLength - class is not specified, PublicVars will be tried  
        if (jjj < BuffOneLength) {
          mmm = Buff2[0]; 
    
