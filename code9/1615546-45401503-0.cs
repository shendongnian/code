    public class PictureViewModel : MvxViewModel
    {
        private IMvxPictureChooserTask _pictureTask;
        public PictureViewModel(IMvxPictureChooserTask pictureTask)
        {
            _pictureTask = pictureTask;
        }
        private byte[] _pictureBytes;
        // in some command:
        private void DoTakePicture()
        {
            _pictureTask.TakePicture(500, 500, stream => {
                _pictureBytes = ReadStream(stream);
            }, () => {});
        }
    }
