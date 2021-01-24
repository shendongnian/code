        await Task.WhenAll(
            Enumerable.Range(0, 100).Select(i => Task.Run(() =>
            {
                byte[] hash;
                using (var hma = new HMACSHA256(keybytes))
                {
                    hash = hma.ComputeHash(tokenBytes);
                }
                //lock (this)
                //{
                //    hash = hmac.ComputeHash(tokenBytes); 
                //}       
                // Both ways achieved the desired results and performance was similar         
                hash.ShouldBeEquivalentTo(expected, $"{i}");
            }))
        );
