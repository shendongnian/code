                sp = new ServicePoint(address)
                {
                    ConnectionLimit = DefaultConnectionLimit,
                    IdleSince = DateTime.Now,
                    Expect100Continue = Expect100Continue,
                    UseNagleAlgorithm = UseNagleAlgorithm
                };
                s_servicePointTable[tableKey] = new WeakReference<ServicePoint>(sp);
