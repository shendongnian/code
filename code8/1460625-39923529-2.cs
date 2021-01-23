    private ConcurrentDictionary<string, BoneKeyFrameCollection> dict =
                new ConcurrentDictionary<string, BoneKeyFrameCollection>();
    
     public BoneKeyFrameCollection this[string boneName]
     {           
            get 
            { 
                return dict[boneName];
            }
    
         public void UpdateBone(string boneName, BoneKeyFrameCollection col)
         {  
            dict[boneName] = col;
         }
    
     }
