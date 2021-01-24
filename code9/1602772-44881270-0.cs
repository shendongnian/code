    public class Connect : Object, Extensibility.IDTExtensibility2, IRibbonExtensibility 
    ... 
 
    public string GetCustomUI(string RibbonID) 
    { 
 
       StreamReader customUIReader = new System.IO.StreamReader("C:\\RibbonXSampleCS\\customUI.xml"); 
 
       string customUIData = customUIReader.ReadToEnd(); 
 
       return customUIData; 
     }
