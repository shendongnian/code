    public class InTurnImageTransition : ImageTransition
    {
        protected override void TransitionToNextImageId()
        {
            if(this.imageId < ImageDictionary.Count)
                this.imageId ++;
        }
    }
    public class RandomImageTransition : ImageTransition
    {
        protected override void TransitionToNextImageId()
        {
            imageId = new Random().Next(0, ImageDictionary.Count);
        }
    }
