    public void TextBlock_Loaded(object sender, EventArgs e)
        {                        
            using (var data = new FeedServiceAgent())
            {
                data.MessageReceived += OnMessageReceived;             
                data.Subscribe("92", 3);
                //DisplayNumber.Text = data.ToString();
                
                //Is this assignment even necessary?
                DisplayNumber.Text = /*Still unclear what goes here because we don't know what how to get from `data` to `Skill`*/            
            }           
        }
        public static void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                if (e == null)
                    return;
                if (e.CmsData == null)
                {
                    //e.CmsData.Skill.AgentsAvailable.ToString();
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { DisplayNumber.Text = e.CmsData.Skill.AgentsAvailable.ToString() ; }
                }
               // if (!String.IsNullOrEmpty(e.Message))
               //     Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                //    logger.Error(" Exception " + ex);
                //    throw ex;
            }
        }
