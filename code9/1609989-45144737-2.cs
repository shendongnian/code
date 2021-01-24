    <div>
        @{ 
            var nonDuplicatedVideos = allVideos.
                .Select(x => x.GetPropertyValue("segment"))
                .Distinct();
        }
        @foreach (var publishedVideo in nonDuplicatedVideos)
        {
            <p>@publishedVideo</p>
        }
    </div>
