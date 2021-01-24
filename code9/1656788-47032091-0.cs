      /// <summary>
    /// 
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(string message, int? codeAction=null) : base(message)
        {
            CodeAction = codeAction;
        }
        public int? CodeAction { get; set; }
    }
