    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace YourNamespace
    {
    	public partial class SamplePage : System.Web.UI.Page
    	{
    		protected List<List<string>> LoadTestList;
    
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			List<string> loadTest1 = new List<string> { "a1", "b1", "c1" };
    			List<string> loadTest2 = new List<string> { "a2", "b2", "c2" };
    			List<string> loadTest3 = new List<string> { "a3", "b3", "c3" };
    			List<string> loadTest4 = new List<string> { "a4", "b4", "c4" };
    
    			LoadTestList = new List<List<string>>();
    			LoadTestList.Add(loadTest1);
    			LoadTestList.Add(loadTest2);
    			LoadTestList.Add(loadTest3);
    			LoadTestList.Add(loadTest4);
    		}
    	}
    }
