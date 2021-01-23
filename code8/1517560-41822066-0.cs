    // act
    var result = client.SendAsync(request).GetAwaiter().GetResult();
    // assert
    result.EnsureSuccessStatusCode();
    var actual = result.Content.ReadAsAsync<Employee>().GetAwaiter().GetResult();
    ... assert on the actual employee instance here
