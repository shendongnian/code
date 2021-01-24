    @using System
    @using ToSic.SexyContent
    @using System.Collections.Generic
    @using System.Linq
    @{
        var items = AsDynamic(App.Data["Document"]);
        var tags = Content.Tags;
        items = items.Where(i => (i.Tags as List<DynamicEntity>).Any(c => ((List<DynamicEntity>)tags).Any(f => c.EntityId == f.EntityId)));
    }
    <div class="sc-element">
        <h1>@Content.Title</h1>
        @Edit.Toolbar(Content)
    </div>
    @foreach(var t in items)
    {
        <div>@t.Title</div>
    }
