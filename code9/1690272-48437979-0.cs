    Objectiv C
    void MultipleDevicesCallMethod(NSMutableArray *devices)
    {
        NSLog(@"devices: %@", devices);
        if(MultipleDevicesLastCallBack != NULL){
            @autoreleasepool {
               devs_ = (char*)malloc((int)[devices count]+2 * sizeof(char));
               for (NSString *s in devices) {
                   
                   if(strlen(devs_) > 0){
                       const char *d = "/";
                       strcat(devs_,d);
                       strcat(devs_, [s UTF8String] );
                   }
                   else{
                       strcpy(devs_, [s UTF8String]);
                   }
                   
               }
            
                
            }
            
            MultipleDevicesLastCallBack(devs_);
           
        }
    }
         C#
         public delegate void UnityMultipleDevicesCallbackDelegate(string devices);
    	[DllImport ("__Internal", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
    	public static extern void MultipleDevicesConnectCallback(UnityMultipleDevicesCallbackDelegate callbackMethod);
    	[MonoPInvokeCallback(typeof(UnityMultipleDevicesCallbackDelegate))]
    	private static void MultipleDevicesCallback([MarshalAs(UnmanagedType.LPStr)]string devices)
    	{
    		
    		BLEdevices = (String)devices.Clone();
    		Debug.Log ("Multiple devices callback now " + BLEdevices);
    		Freedevs_ ();
    	}
