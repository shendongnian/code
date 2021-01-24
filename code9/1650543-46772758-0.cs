            // object lifetime transient or others.. determine according to your needs
            services.AddTransient<TxtPreprocessor>();
            services.AddTransient<DocPreprocessor>();
            services.AddTransient(processorFactory =>
            {
                Func<DocType, IDocumentPreprocessor> factoryFunc = docType =>
                {
                    switch (docType)
                    {
                        case DocType.Txt:
                            return processorFactory.GetService<TxtPreprocessor>();
                        default:
                            return processorFactory.GetService<DocPreprocessor>();// DocPreprocessor is defult
                    }
                };
                return factoryFunc;
            });
