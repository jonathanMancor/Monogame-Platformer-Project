using mg_Project_03.Core;
using mg_Project_03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Maps
{
    internal class Background : Component
    {

        Texture2D texture;
        string fileName;
        Vector2 dimensions;
        Vector2 position = new Vector2(0,0);

        public Background(string fileName)
        {
            this.fileName = fileName;
            
        }
        internal override void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(fileName);
            this.dimensions = new Vector2(texture.Width, texture.Height);
        }

        internal override void Update(GameTime gameTimer)
        {
            
        }
        public void UpdatePos(GameTime gameTimer, Entity player)
        {
            float p = -0.0000000000001f;
            this.position = new Vector2(player.position.X * p - dimensions.X / 2, player.position.Y * p - dimensions.Y / 2);
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
