    public class ImageListResult
    {
        public List<ImageSlot> Slots { get; set; }
        public ImageListResult(dynamic res)
        {
            this.Slots = new List<ImageSlot>();
            try {
                int keys = res.Keys.Count;
                int values = res.Values.Count;
                if (keys == values)
                {
                    for (int i = 0; i < keys; i++)
                    {
                        ImageSlot slot = new ImageSlot()
                        {
                            Index = int.Parse(res.Keys[i])
                        };
                        int subCount = res.Values[i].Keys.Count;
                        for (int j = 0; j < subCount; j++)
                        {
                            string k = res.Values[i].Keys[j];
                            string v = res.Values[i].Values[j];
                            if (k.ToLower().Trim() == "imageid")
                            {
                                slot.ImageId = v;
                            }
                            else if(k.ToLower().Trim() == "imageurl")
                            {
                                slot.ImageUrl = v;
                            }
                        }
                        this.Slots.Add(slot);
                    }
                }
            }catch(Exception ex)
            {
            }
        }
        public class ImageSlot
        {
            /// <summary>
            /// το index του image slot, απο το 1 εως το 25
            /// </summary>
            public int Index { get; set; } 
            public string ImageId { get; set; }
            public string ImageUrl { get; set; }
        }
        
    }
