    string[] DTColumn1 = {
    	"1-foo",
    	"2-bar",
    	"3-foobar"
    };
    string[] DTColumn2 = {
    	"1-foo2",
    	"3-foobar2"
    };
    
    
    //Find the longest array of the two
    string[] longestArray = DTColumn1;
    string[] shortestArray = DTColumn2;
    
    if (DTColumn2.Length > longestArray.Length) {
    	longestArray = DTColumn2;
    	shortestArray = DTColumn1;
    }
    
    
    //Instantiating new lists to show data
    List<string> col1 = new List<string>();
    List<string> col2 = new List<string>();
    
    
    //Filling "interface" lists with data
    foreach (void value_loopVariable in longestArray) {
    	value = value_loopVariable;
    	col1.Add(value);
    }
    
    //This can be tricky, but I really have no idea of how your data is structured
    foreach (void value1_loopVariable in col1) {
    	value1 = value1_loopVariable;
    
    	foreach (void value2_loopVariable in shortestArray) {
    		value2 = value2_loopVariable;
    		if (value1[0].Equals(value2[0])) {
    			col2.Add(value2);
    			break;
    		}
    
    		//When the program reaches this point means that there is no corrispondace of data, so we add an empty value to col2
    		col2.Add("");
    
    	}
    
    }
    //Here you'll have col1 and col2 filled with data
