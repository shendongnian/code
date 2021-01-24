      if (timer1.Enabled == false)
                            {
    timer1.Enabled = true;
                            for (int i = 0; i < array.Length; i++)
                                {
                                 YouTubeVideo video = new Helix.YouTubeVideo(array2[i]);
                                 var gDur = getDuration(video.duration);
                                 string[] time = gDur.ToString().Split(' ');
                                 int min = int.Parse(time[0]);
                                 int sec = int.Parse(time[1]);
                                 int msm = min * 60000;
                                 int mss = sec * 1000;
                                 int dur = msm + mss;
                                 timer1.Interval = dur;
        
                                 Video.Movie = array[i];
                                timer1.Start();
                                client.SendMessage("Now playing: " + video.title + ".");
                                client.SendMessage($"Timer set to { dur } ms.");
                            }
                          }
