using mg_Project_03.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Controls
{
    internal class KeyboardInputs
    {
        public void Input(GameTime gameTime, Entity e)
        {

            Console.WriteLine(e.isCollide[0] +"|"+ e.isCollide[1] + "|" + e.isCollide[2] + "|" + e.isCollide[3]);
            e.position += e.velocity;
            int velQuatient = 4;//1500;
            float vel = (float)gameTime.ElapsedGameTime.TotalMilliseconds / velQuatient;

            
            if (e.velocity.Y < vel * 1.6)
            {

                e.velocity.Y += 0.5f;
            }


            if (Keyboard.GetState().IsKeyDown(Keys.W) && !e.hasJump)
            {


                //e.velocity.Y = -vel * 2.5f;
                e.position.Y -= 5f;
                e.velocity.Y += -vel;
                e.hasJump = true;

                if (e.isCollide[2])
                {
                    
                    e.isCollide[2] = false;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {

                if (e.isCollide[1])
                {
                    e.position.X += 1;
                    e.isCollide[1] = false;
                    
                    
                }
                e.velocity.X = vel;
                
            }

            /*else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {

                e.velocity.Y = vel;
            }*/
            
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (e.isCollide[3])
                {
                    e.isCollide[3] = false;
                    e.position.X -= 1;
                }
                e.velocity.X = -vel;
            }
            else
            {
                e.velocity.X = 0f;
                //e.velocity.Y = 0f;
            }
            
            
        }
    }
}
