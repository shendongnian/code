    List<WebElement> starRatings = driver.findElements(By.xpath("//div[contains(@title, 'star rating')]"));
    List<WebElement> businesses = driver.findElements(By.xpath("//div[contains(@title, 'star rating')]/preceding::a[1]/span"));
    for(int i = 0; i < starRatings.size(); i++)
    {
           String rating = starRatings.get(i).getAttribute("title");
           rating = rating.split(" ")[0];
           DecimalFormat df = new DecimalFormat("#.#");
           Double d = Double.valueOf(rating);
           rating = df.format(d);
           d = Double.valueOf(rating);
           if(d <= 3)
           {
                String Businessname = businesses.get(i).getText();
                //Write variable Businessname & rating into file 
           }
    }
