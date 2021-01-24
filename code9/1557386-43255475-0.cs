            private void Neutral_stance(Body body, IReadOnlyDictionary<JointType, Joint> joints, IDictionary<JointType, Point> jointPoints, BodyFrame bf)
        {
            //cameraspace point joint stuff here again (see original post for this bit leading up to the if statements.)
            if (bf != null)
            {
                TimeSpan frametime = bf.RelativeTime;
                string path_s = @"C:\Users\aheij\Desktop\KinectOutput\swipe.txt";
                if (left_hand.Y < left_elbow.Y)
                {
                    if (right_hand.Y < right_elbow.Y)
                    {
                        if (shoulderhand_xrange_l < vertical_error)
                        {
                            if (shoulderhand_xrange_r < vertical_error)
                            {
                                Gesture_being_done.Text = "  Neutral";
                                FileStream fs_s = new FileStream(path_s, FileMode.Append); //swipe
                                byte[] bdatas = Encoding.Default.GetBytes(frametime.ToString() + "    Neutral" + Environment.NewLine);
                                fs_s.Write(bdatas, 0, bdatas.Length);
                                fs_s.Close();
                            }
                        }
                    }
                }
                else
                {
                    Gesture_being_done.Text = "  Unknown";
                    FileStream fs_s = new FileStream(path_s, FileMode.Append);
                    byte[] bdatas = Encoding.Default.GetBytes(frametime.ToString() + "    Unknown" + Environment.NewLine);
                    fs_s.Write(bdatas, 0, bdatas.Length);
                    fs_s.Close();
                  }
            }
        }
