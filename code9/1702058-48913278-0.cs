                            ServiceController sc = new ServiceController("ServiceName");
                            switch (sc.Status)
                            {
    
                                case ServiceControllerStatus.Running:
                                    break;
                                case ServiceControllerStatus.Stopped:
                                    break;
                                case ServiceControllerStatus.Paused:
                                break;
                                .
                                .
                                .
                                .
                            }
