using mg_Project_03.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Maps
{
    internal class Tile : Component
    {
        protected Texture2D texture;
        protected Rectangle srcRect;
        public Vector2 position;
        public Rectangle collider;



        internal override void LoadContent(ContentManager Content)
        {
            throw new NotImplementedException();
        }

        internal override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, srcRect, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.None, 1.0f);
        }
    }
}
