using mg_Project_03.Core;
using mg_Project_03.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Managers
{
    internal partial class StateManager : Component
    {

        private MainMenuState mainMenu = new MainMenuState();
        private Barracks_level_state world_1 = new Barracks_level_state();

        internal override void LoadContent(ContentManager Content)
        {
            mainMenu.LoadContent(Content);
            world_1.LoadContent(Content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.State.MainMenu:
                    mainMenu.Update(gameTime);
                    break;
                case Data.State.Settings:
                    break;
                case Data.State.Inventory:
                    break;
                case Data.State.World_1:
                    world_1.Update(gameTime);
                    break;
                case Data.State.World_2:
                    break;
            }
        }

        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.State.MainMenu:
                    mainMenu.Draw(spriteBatch);
                    break;
                case Data.State.Settings:
                    break;
                case Data.State.Inventory:
                    break;
                case Data.State.World_1:
                    world_1.Draw(spriteBatch);
                    break;
                case Data.State.World_2:
                    break;
            }
        }
    }
}
