    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(logObject) + "\n")))
    {
        PutRecordRequest putRecordRequest = new PutRecordRequest() { DeliveryStreamName = this.streamName, Record = new Record() { Data = ms } };
        // Put record into the DeliveryStream
        using (PutRecordResponse response = await client.PutRecordAsync(putRecordRequest))
        {
            return response.HttpStatusCode == HttpStatusCode.Ok;
        }
    }
