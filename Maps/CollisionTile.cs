using mg_Project_03.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Maps
{
    internal class CollisionTile : Tile
    {
        public CollisionTile(Texture2D tex, Vector2 pos, Rectangle rect)
        {
            texture = tex;
            srcRect = rect;
            position = pos;
            collider = new Rectangle((int)pos.X, (int)pos.Y, rect.Width, rect.Height);
        }
    }
}
