    public Sprite RadarImageToChange;
    
    public void ChangeImage(Sprite UpdateImage)
    {
            if(gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Image>().sprite = RadarImageToChange;
            }
    }
