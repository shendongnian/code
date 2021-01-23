    // Get the Hierarchy object that organizes the loggers
    					Hierarchy hier = log4net.LogManager.GetRepository() as Hierarchy;
    					if (hier != null)
    					{
    						// Get Appender
    						FileAppender fileAppender =
    							(FileAppender)hier.GetAppenders().Where(
    								appender => appender.Name.Equals("MyLogger", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    
    						if (fileAppender != null)
    						{
    							fileAppender.File = Input.Substring(6);
    							
    							//refresh settings of appender
    							fileAppender.ActivateOptions();							
    						}
    					}
