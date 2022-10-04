using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mg_Project_03.Core
{
    public static class Data
    {
        public static string Name { get; set; }
        public static int ScreenWidth { get; set; } = 1080;
        public static int ScreenHeight { get; set; } = 800;
        public static bool Exit { get; set; } = false;

        public static string CsvPath { get; set; } = "../../../csv/";

        public static int EntitySize { get; set; } = 64;
        public static int TileSize { get; set; } = 32;

        

        public enum State
        {
            MainMenu,
            Settings,
            Inventory,
            World_1,
            World_2,
        }

        public static State CurrentState { get; set; } = State.MainMenu;
    }
}
