using mg_Project_03.Core;
using mg_Project_03.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Maps
{
    internal class Map : Component
    {
        string[] csvFiles = new string[2];
        string tileSetFile;
        internal Vector2 tileSetSize;
        Texture2D texture;
        int[,] map;
        int tileSize = Data.TileSize;
        Vector2 mapSize;



        public List<CollisionTile> collisionTiles = new List<CollisionTile>();
        public List<CollisionTile> groundTiles = new List<CollisionTile>();

        Background background;

        public Map(string csvMap, string tileSet, string background)
        {
            tileSetFile = tileSet;
            
            csvFiles[0] = csvMap + "_collisions.csv";
            csvFiles[1] = csvMap + "_ground.csv";
            this.background = new Background(background);
        }

        internal void Generate(string csvFile)
        {
            //extracts csv file content
            string[] csvStrings = new string[File.ReadAllLines(Data.CsvPath + csvFile).Length];
            csvStrings = File.ReadAllLines(Data.CsvPath + csvFile);

            //set map dimensions
            mapSize = new Vector2(csvStrings[1].Split(",").Length, csvStrings.Length);
            map = new int[(int)mapSize.X, (int)mapSize.Y];

            for(int y = 0; y < mapSize.Y; y++)
            {
                string[] tmpString = csvStrings[y].Split(",");
                
                for(int x = 0; x < mapSize.X; x++)
                {
                    int tValue = int.Parse(tmpString[x]);
                    map[x, y] = tValue;

                    if (tValue != -1)
                    {
                        Vector2 tileSetPos;
                        int xPos = 0;
                        int yPos = 0;

                        for (int t = 0; t < tValue; t++)
                        {
                            xPos++;
                            if(xPos > tileSetSize.X)
                            {
                                xPos = 0;
                                yPos++;
                            }
                        }

                        tileSetPos = new Vector2(xPos, yPos);



                        if (csvFile == this.csvFiles[0])
                            collisionTiles.Add(new CollisionTile(texture, new Vector2(tileSize * x, tileSize * y), new Rectangle(tileSize * tValue, tileSize * 0, tileSize, tileSize)));


                        if (csvFile == this.csvFiles[1])
                            groundTiles.Add(new CollisionTile(texture, new Vector2(tileSize * x, tileSize * y), new Rectangle((int)(tileSize * tileSetPos.X), (int)(tileSize * tileSetPos.Y), tileSize, tileSize)));



                    }
                }
            }

        }

        /*internal Vector2 TileSet(int val)
        {



        }*/



        internal override void LoadContent(ContentManager Content)
        {
            
            texture = Content.Load<Texture2D>(tileSetFile);
            foreach( string map in csvFiles)
            {
                Generate(map);
            }
            
            Trace.WriteLine(mapSize.X + " | " + mapSize.Y);
            background.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void UpdateBackground(GameTime gameTime, Entity player)
        {
            this.background.UpdatePos(gameTime, player);
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);   
            foreach(Tile tile in groundTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
