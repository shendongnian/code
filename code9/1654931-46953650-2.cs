    var searchString = "amet";
    var content = new[]
    {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer mollis eros at ligula ultricies consequat. Quisque consequat at quam sed gravida. Fusce dapibus nisi a ex mollis, in hendrerit massa tincidunt. Quisque a dictum nisi, vitae bibendum quam. Pellentesque vitae dui a quam condimentum cursus. Mauris id interdum lorem, eu congue ligula. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent lobortis cursus nulla, vitae vehicula velit pretium sed. Maecenas nisl tellus, gravida pharetra justo nec, ultrices tempus mi.",
        "Ut id lectus dapibus, commodo mauris in, consectetur magna. Phasellus porttitor nisl malesuada quam pulvinar, sed eleifend eros tristique. Proin id magna eros. Morbi iaculis mattis magna nec pellentesque. Donec lacinia aliquam nibh, vel accumsan erat pharetra eget. Proin ut est accumsan, fringilla ex et, congue arcu. Nulla iaculis non lectus condimentum dictum.",
        "In hac habitasse platea dictumst. Integer at quam maximus, consectetur lectus sed, consequat nunc. Morbi ultrices nisi vel porttitor lobortis. Vestibulum rutrum dignissim purus, sit amet semper libero egestas in. Pellentesque sodales augue et commodo porta. Nullam eu mattis tortor. Aenean scelerisque pretium mi, ullamcorper malesuada metus gravida sed. Morbi rhoncus tincidunt hendrerit. Suspendisse ac sollicitudin nisl. Curabitur congue faucibus lacinia. Donec felis lectus, luctus id nunc non, efficitur tincidunt orci. Donec turpis massa, ultrices sit amet ex nec, laoreet scelerisque metus. Quisque id neque ac leo volutpat maximus in at erat. Nunc commodo, sapien sit amet elementum ullamcorper, justo velit condimentum dui, at condimentum eros eros vel enim. Maecenas gravida dui vel sem gravida auctor.",
        "Ut quam ligula, pellentesque nec placerat vel, scelerisque finibus nibh. Donec eu felis a felis gravida auctor. Mauris sollicitudin aliquam tellus. Praesent ac neque lacus. Donec quis sagittis nisl. Nunc at mauris dolor. Donec sagittis, erat sit amet elementum bibendum, lorem mauris vestibulum odio, id egestas risus ante vel tortor. Donec sit amet rhoncus velit. Interdum et malesuada fames ac ante ipsum primis in faucibus.",
        "Maecenas vehicula luctus neque vel pretium. Proin lacinia nec lectus eget faucibus. Maecenas tristique elementum consequat. Nunc convallis nibh lorem, non porttitor tellus maximus a. Ut tristique neque ac lorem pulvinar maximus. Nulla id odio nec libero facilisis feugiat. Aenean sed elit vel sem luctus rhoncus ut non lorem. Vivamus eu imperdiet arcu. Cras tempor sapien eget nunc ullamcorper efficitur. Curabitur eget blandit ligula, euismod mollis metus. Vestibulum interdum, purus sit amet porttitor semper, leo dolor feugiat libero, sed luctus diam ex non mauris. Curabitur a efficitur sapien. Quisque et gravida magna. Proin ut condimentum neque, nec sodales arcu. Nulla vitae cursus purus. Ut id enim sapien."
    };
    
    // Query (modified due to different data source here)
    var query = (from c in content
                where c.Contains(searchString)
                select new
                {
                    ContentText = c
                });
    
    // Size of the preview
    var previewLength = 10;
    
    // Get all the results
    foreach (var contentText in query.ToList())
    {
        var paragraph = contentText.ContentText;
        Console.WriteLine(GetPreview(searchString, previewLength, paragraph));
    }
