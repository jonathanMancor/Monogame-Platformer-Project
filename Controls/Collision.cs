using mg_Project_03.Entities;
using mg_Project_03.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Controls
{
    static class Collision
    {
        const int margin = 5;
        
        public static bool BottomCollide(this Rectangle r1, Rectangle r2)
        {
            return (

                    r1.Bottom >= r2.Top - margin * 2 &&
                    r1.Bottom <= r2.Top + margin &&
                    r1.Right >= r2.Left + margin &&
                    r1.Left <= r2.Right - margin
                );
        }

        public static bool TopCollide(this Rectangle r1, Rectangle r2)
        {
            return (

                    r1.Top <= r2.Bottom + margin &&
                    r1.Top >= r2.Bottom - margin &&
                    r1.Right >= r2.Left + margin &&
                    r1.Left <= r2.Right - margin
                );
        }

        public static bool RightCollide(this Rectangle r1, Rectangle r2)
        {
            return (

                    r1.Right <= r2.Right  &&
                    r1.Right >= r2.Left - margin &&
                    r1.Top <= r2.Bottom - margin &&
                    r1.Bottom >= r2.Top + margin
                );
        }

        public static bool LeftCollide(this Rectangle r1, Rectangle r2)
        {
            return (

                    r1.Left >= r2.Left  &&
                    r1.Left <= r2.Right + margin &&
                    r1.Top <= r2.Bottom - margin &&
                    r1.Bottom >= r2.Top + margin
                );
        }

        public static void OnCollide(this Entity e, Map m)
        {
            int colliderMargin = (e.srcRect.Width - e.collider.Width) / 2;
            for (int i = 0; i < m.collisionTiles.Count(); i++)
            {
                Rectangle tile = m.collisionTiles[i].collider;

                if (e.collider.TopCollide(tile))
                {
                    e.isCollide[0] = true;
                    e.velocity.Y = 1f;
                    e.position.Y = tile.Y + tile.Height + 1;
                    
                }
                //else if (!e.collider.TopCollide(tile)) { e.isCollide[0] = false; }

                if (e.collider.LeftCollide(tile))
                {
                    e.isCollide[1] = true;
                    e.position.X = tile.X + tile.Width - colliderMargin + 5;
                    e.velocity.X = 0;
                }
                //else if (!e.collider.LeftCollide(tile)) { e.isCollide[1] = false; }

                if (e.collider.BottomCollide(tile))
                {
                    e.isCollide[2] = true;
                    e.position.Y = tile.Y - e.collider.Height;
                    e.velocity.Y = 0;
                    e.hasJump = false;
                }
                //else if(!e.collider.BottomCollide(tile)) { e.isCollide[2] = false; }

                if (e.collider.RightCollide(tile))
                {
                    e.isCollide[3] = true;
                    e.position.X = tile.X - e.srcRect.Width + colliderMargin - 5;
                    e.velocity.X = 0;
                }
                //else if (!e.collider.RightCollide(tile)) { e.isCollide[3] = false; }

            }
        }

    }
}
