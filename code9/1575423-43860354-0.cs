    var cityNames = new List<string> {"New York",
                                      "Atlanta",
                                      "Hartford",
                                      "Chicago"
                                      };
    var anyResult = cityNames.Any(x=>x== "Hartford"); //TRUE
    var whereResult = cityNames.Where(x => x == "Hartford"); //IEnumerable<string>, in this case only one element
