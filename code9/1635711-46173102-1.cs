    <div id="pageTitleText">[@Model.Item.Key]
         @if (!Model.IsUserReadonly && !Model.ReadOnlyCachesList.Contains(Model.CacheName))
         {
    
    
             <span class="itemActions">
                 <a class="edit" href="@Url.Content("~/caches")/@Model.CacheName/edit?key=@Url.Encode("PICO+")">Edit</a>
                 <a class="clone" href="@Url.Content("~/caches")/@Model.CacheName/clone?key=@Url.Encode("PICO+")">Clone</a>
                 <a id="evictItem" class="evict" href="#">Evict</a>
                 <a id="deleteItem" class="delete" href="#">Delete</a>
             </span>
         }
    </div>
