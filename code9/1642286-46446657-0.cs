    using System;
    using TiledSharp;
    using System.Xml.Linq;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;
    
    namespace Platformer
    {
        class Level
        {
            public Level(TmxMap map, Texture2D tileSet)
            {
                var tileMap = map;
                Texture2D levelTilesetTexture = tileSet;
    
                int tileWidth = tileMap.Tilesets[0].TileWidth;
                int tileHeight = tileMap.Tilesets[0].TileHeight;
                int tilesetTilesWide = levelTilesetTexture.Width / tileWidth;
                int tilesetTilesHigh = levelTilesetTexture.Height / tileHeight;
                GameInfo.gameInfo.bottomOfLevel = tileMap.Height * tileHeight;
                GameInfo.gameInfo.leftOfLevel = 0;
    
    
                int staticObjectSpriteWidth = tileMap.TileWidth;
                int staticObjectSpriteHeight = tileMap.TileHeight;
                Vector2 staticObjectBoundingBoxOffset = new Vector2(0, 0);
                int staticObjectBoundingBoxWidth = tileMap.TileWidth;
                int staticObjectBoundingBoxHeight = tileMap.TileHeight;
                bool oneWayPlatform = false;
                bool collisionObject = true;
                bool ignore = false;
                int drawLayer = 1;
    
                for (var i = 0; i < tileMap.Layers[0].Tiles.Count; i++)
                {
                    int tileNumber = tileMap.Layers[0].Tiles[i].Gid;
                    if (tileNumber != 0)   // If not empty tile.
                    {
                        tileNumber--;
                        var tileProperties = tileMap.Tilesets[0].Tiles[tileNumber].Properties;
                        string ignoreValue = "nothing";
                        string oneWayValue = "nothing";
                        tileProperties.TryGetValue("Ignore", out ignoreValue);
                        ignore = Convert.ToBoolean(ignoreValue);
                        tileProperties.TryGetValue("OneWay", out oneWayValue);
                        oneWayPlatform = Convert.ToBoolean(oneWayValue);
    
                        int column = tileNumber % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileNumber / (double)tilesetTilesWide);
    
                        float x = (i % tileMap.Width) * tileMap.TileWidth;
                        float y = (float)Math.Floor(i / (double)tileMap.Width) * tileMap.TileHeight;
    
                        PlatformerGame.game.CreateStaticObject(levelTilesetTexture, new Vector2(x, y), staticObjectSpriteWidth, staticObjectSpriteHeight,
                                staticObjectBoundingBoxOffset, staticObjectBoundingBoxWidth, staticObjectBoundingBoxHeight,
                                column, row, oneWayPlatform, collisionObject, drawLayer, ignore);
                    }
                }
            }
        }
    }
