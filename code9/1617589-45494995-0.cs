          IAsset inputAsset = _mediaContext.Assets.CreateFromBlob(blob, 
                                storageCredentials, AssetCreationOptions.None);
          inputAsset.AlternateId = assetId.ToString();
          inputAsset.Update();
 
