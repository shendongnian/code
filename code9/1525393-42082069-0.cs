                string likeCondition = string.Empty;
    			string textBoxContent = "Programming1,Database";// use TextBox3.Text here
    	        var splittedContents = textBoxContent.Split(',').ToList();
    	        int index = 0;
    	        foreach (var splittedContent in splittedContents)
    	        {
    				
    		        likeCondition += "CourseName LIKE %" + splittedContent + "%";
    		        index++;
    		        if (index != splittedContent.Length)
    			        likeCondition += " OR ";
    
    	        }
