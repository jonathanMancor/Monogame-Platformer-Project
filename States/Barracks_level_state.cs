using mg_Project_03.Controls;
using mg_Project_03.Core;
using mg_Project_03.Entities;
using mg_Project_03.Maps;
using mg_Project_03.Maps.BunkerMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.States
{
    internal class Barracks_level_state : Component
    {
        //Camera
        private Camera camera;

        //Map variables
        private Map map = new Barracks_level_map("bunker/bunker", "tileSet_32x32_bunker", "bg_mushroom_test");
        //private CollisionHelper collisionHelper = new CollisionHelper();

        //Entity variables
        private Player player = new Player(64, 96);

        
        
        
        


        internal override void LoadContent(ContentManager Content)
        {
            //Camera
            camera = new Camera(new Vector2(0, 0));
            //Maps
            map.LoadContent(Content);
            //Entities
            player.LoadContent(Content);
           
            
        }

        internal override void Update(GameTime gameTime)
        {
            //Camera
            camera.Update(player);



            //Player 
            
            player.Update(gameTime);



            player.OnCollide(map);
            player.controlsK.Input(gameTime, player);

            //Map

            

            map.UpdateBackground(gameTime, player);












        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.transform);

            //Maps
            map.Draw(spriteBatch);

            //Entities
            player.Draw(spriteBatch);

            


            


            spriteBatch.End();
        }
    }
}
