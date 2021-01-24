    <div>
        @{ 
            var nonDuplicatedVideos = allVideos.
                .Select(x => x.GetPropertyValue("segment")
                .Distinct()
                .ToList() 
        }
        @foreach (var publishedVideo in nonDuplicatedVideos)
        {
            <p>@publishedVideo</p>
        }
    </div>
