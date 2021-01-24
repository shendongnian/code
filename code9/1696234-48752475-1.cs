    <div class="my-styles">
       <h2>@Title</h2>
       @RenderContent(Body)
       <button onclick=@OnOK>OK</button>
    </div>
    @functions {
        public string Title { get; set; }
        public Content Body { get; set; }
        public Action OnOK { get; set; }
    }
