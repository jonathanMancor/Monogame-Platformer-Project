using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mg_Project_03.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mg_Project_03.Core
{
    internal class Camera
    {
        public Vector2 position;
        public Matrix transform { get; private set; }
        //public float delay { get; set; }

        public Camera(Vector2 position)
        {
            this.position = position;
        }

        public void Update(Entity e)
        {
            //float d = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 5;
            position.X += ((e.collider.X - position.X) - Data.ScreenWidth / 2) ;
            position.Y += ((e.collider.Y - position.Y) - Data.ScreenHeight / 2);

            transform = Matrix.CreateTranslation(-position.X, -position.Y, 0);
        }





        //////////////////////////////////////////////////////////////////////////////////
        /*public Matrix Transform { get; private set; }

        public void Focus(Entity target)
        {

            var position = Matrix.CreateTranslation(
                target.position.X + (target.collider.Width / 2),
                target.position.Y + (target.collider.Height / 2),
                0);
            var offset = Matrix.CreateTranslation(
                Data.ScreenWidth / 2,
                Data.ScreenHeight / 2,
                0);

            //Transform = position * offset;
            Transform = position;
        }*/
    }
}
