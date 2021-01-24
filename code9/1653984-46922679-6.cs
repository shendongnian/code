            public void LockOrientation()
            {
                CMMotionManager CMManager = new CMMotionManager();
                CMManager.DeviceMotionUpdateInterval = 0.2f;
                CMManager.StartDeviceMotionUpdates(NSOperationQueue.MainQueue, (motion, error) => {
                    if (Math.Abs(motion.Gravity.X) > Math.Abs(motion.Gravity.Y))
                    {
                        Console.WriteLine("Lan");
                        if (motion.Gravity.X > 0)
                        {
                            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
                            Console.WriteLine("Left");
                        }
                        else
                        {
                            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeRight), new NSString("orientation"));
                            Console.WriteLine("Right");
                        }
                    }
                    else
                    {
                        if (motion.Gravity.Y >= 0)
                        {
                            Console.WriteLine("Down");
                        }
                        else
                        {
                            Console.WriteLine("UP");
                        }
                    }
                    CMManager.StopDeviceMotionUpdates();
                });
            }
