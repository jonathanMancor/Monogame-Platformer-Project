using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.Json;
using mg_Project_03.Managers;
using mg_Project_03.Entities;
using System.Diagnostics;

namespace mg_Project_03.Core
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StateManager _stateManager;
        private PlayerStats _playerStats;
        private const string SAVE_PATH = "stats.json";

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //set game window
            _graphics.PreferredBackBufferWidth = Data.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Data.ScreenHeight;
            _graphics.ApplyChanges();

            _stateManager = new StateManager();
           

            base.Initialize();
        }

        protected override void LoadContent()
        {


            _playerStats = new PlayerStats()
            {
                Name = "jon",
                Health = 10
            };
            //Save(_playerStats);
            _playerStats = Load();
            Trace.WriteLine($"{_playerStats.Name},{_playerStats.Health}");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _stateManager.LoadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            

            if(Data.Exit)Exit();

            _stateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            _stateManager.Draw(_spriteBatch);

            

            base.Draw(gameTime);
        }


        private void Save(PlayerStats stats)
        {
            string serializedText = JsonSerializer.Serialize<PlayerStats>(stats);
            Trace.WriteLine(serializedText);
            File.WriteAllText(SAVE_PATH, serializedText);
        }

        private PlayerStats Load()
        {
            var fileContents = File.ReadAllText(SAVE_PATH);
            return JsonSerializer.Deserialize<PlayerStats>(fileContents);
        }
    }
}