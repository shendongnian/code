      protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == LocationEnabled.REQUEST_CHECK_SETTINGS)
            {
                switch (resultCode)
                {
                    case Result.Canceled:
                     //negative result 
                        break;
                    case Result.Ok:
                   //positive result 
                        break;
                    case Result.FirstUser:
                    default:
                        break;
                }
            }
        }
