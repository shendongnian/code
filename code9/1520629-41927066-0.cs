    public class Game
    {
        //...
        [NotMapped]
        public Image? Image { get; set; }  //<== see ? to make it nullable
    
        [NotMapped]
        public List<Image> Images { get; set; }
    
        public string Image_Serialized
        {
            get
            {
    			if(Image == null)
    				return null;
                return JsonConvert.SerializeObject(Image);
            }
            set
            {
    			if(value == null)
    				Image = null;
    			else
    				Image = JsonConvert.DeserializeObject<Image>(value);
            }
        }
    }
