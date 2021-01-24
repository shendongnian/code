    public class GraphicItem : Base
    {
        public int GraphicId { get; set; }
        public virtual Graphic Graphic { get; set; }
        public int? GraphicUploadTemplateItemId { get; set; }
        public virtual GraphicUploadTemplateItem UploadTemplate { get; set; }
    }
