    [TV (11,0), Mac (10,13, onlyOn64: true), iOS (11,0)]
	[Abstract]
	[DisableDefaultCtor]
	[BaseType (typeof (VNImageBasedRequest))]
	interface VNDetectBarcodesRequest {
		[Export ("initWithCompletionHandler:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] VNRequestCompletionHandler completionHandler);
		[Static]
		[Protected]
		[Export ("supportedSymbologies", ArgumentSemantic.Copy)]
		NSString [] WeakSupportedSymbologies { get; }
		[Static]
		[Wrap ("VNBarcodeSymbologyExtensions.GetValues (WeakSupportedSymbologies)")]
		VNBarcodeSymbology [] SupportedSymbologies { get; }
		[Protected]
		[Export ("symbologies", ArgumentSemantic.Copy)]
		NSString [] WeakSymbologies { get; set; }
	}
