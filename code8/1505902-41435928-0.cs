    public static class MyExtension
    {
        public static PictureBox DeepCopy(this PictureBox pb)
        {
            return new PictureBox { Name = pb.Name, Image = pb.Image, Size = pb.Size, SizeMode = pb.SizeMode };
        }
    }
