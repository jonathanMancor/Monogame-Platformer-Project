using mg_Project_03.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Entities
{
    internal class Entity : Component
    {
        public Texture2D texture;
        public Rectangle srcRect;
        public Rectangle collider;
        public Vector2 position;

        
        internal Vector2 velocity;


        public bool hasJump = false;
        public bool[] isCollide = new bool[4];

        //animation
        float timer;
        int currentFrame;
        int maxFrames = 6;





        public Entity(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }





        internal override void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ss_64_treeling");
            
           
        }





        internal override void Update(GameTime gameTime)
        {
            AnimateEntity(gameTime);
            //currentFrame * 32
            srcRect = new Rectangle(0,0,Data.EntitySize, Data.EntitySize);

            collider = new Rectangle((int)position.X, (int)position.Y, Data.EntitySize, Data.EntitySize);
            //position += velocity; 
            
            
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, srcRect, Color.White, 0.0f, new Vector2(0, 0), new Vector2(1.0f, 1.0f), SpriteEffects.None, 1.0f);
        }

        public void AnimateEntity(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 0.2)
            {
                timer = 0.0f;
                currentFrame += 1;
            }
            currentFrame = currentFrame % maxFrames;
            
        }


    }
}
