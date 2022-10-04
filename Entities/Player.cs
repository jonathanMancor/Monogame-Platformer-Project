using mg_Project_03.Controls;
using mg_Project_03.Core;
using mg_Project_03.Managers;
using mg_Project_03.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Entities
{
    internal class Player : Entity
    {
        public KeyboardInputs controlsK = new KeyboardInputs();

        public Player(int x, int y) : base(x, y)
        {
        }

        internal override void Update(GameTime gameTime)
        {
            AnimateEntity(gameTime);
            //currentFrame * 32
            srcRect = new Rectangle(0, 0, Data.EntitySize, Data.EntitySize);

            collider = new Rectangle((int)position.X + Data.EntitySize / 4, (int)position.Y, Data.EntitySize / 2, Data.EntitySize);
            //position += velocity;


            


        }

    }
}
