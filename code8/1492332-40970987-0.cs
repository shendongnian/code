    var userIdGroups = db.TableName.GroupBy(x => x.user_id).AsEnumerable();
    var itemsWithColors = userIdGroups
        .SelectMany(g => g.Select((x, index) => index == 0
            ? new { Item = x, Color = Color.Black }
            : new { Item = x, Color = Color.Red   }));
