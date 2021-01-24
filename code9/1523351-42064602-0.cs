     //Your code
      catch (HttpRequestException ex)
      {
          //ConnectionException();
          loadingLogin.IsActive = false;
      }
      //Add following code
      if (loadingLogin.IsActive == false)
      {
          isstoreTapped = false;
          iskoleksiTapped = false;
      }
