    public async Tack<IHttpActionResult> WorkMethod(TestObject testObject)
    {
        Debug.WriteLine("WorkMethod - before calling asyncMethod1");
        await this.asyncMethod1(testObject);
        Debug.WriteLine("WorkMethod - after calling asyncMethod1");
        return Ok();
    }
