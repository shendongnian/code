    public void ImagesLinks()
                {
                    int count = 0;
                    foreach(string c in DatesAndTimes)
                    {
                        if (count == 9)
                        {
                            count = 0;
                            continue;
                        }
                        string imageUrl = firstUrlPart + countriescodes[count] + secondUrlPart + DatesAndTimes[count] + thirdUrlPart + "true";
                        imagesUrls.Add(imageUrl);
                        count++;
                    }
                }
