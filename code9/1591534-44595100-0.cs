    SafariDriverService serv = SafariDriverService.CreateDefaultService("/Applications/Safari Technology Preview.app/Contents/MacOS/", "safaridriver");
					SafariOptions opts = new SafariOptions();
					opts.AddAdditionalCapability(CapabilityType.AcceptSslCertificates, true);
					opts.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates, true);
					opts.AddAdditionalCapability("cleanSession", true);
					webDriver = new SafariDriver(serv, opts);
