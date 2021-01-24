    public interface IAnimalSlide<TImageViewer>
        where TImageViewer : ImageViewer
    {
        void endShow();
        void setNewImage();
        TImageViewer displayImage();
    }
