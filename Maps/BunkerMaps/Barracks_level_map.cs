using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mg_Project_03.Maps.BunkerMaps
{
    internal class Barracks_level_map : Map
    {
        public Barracks_level_map(string csvMap, string tileSet, string background) : base(csvMap, tileSet, background)
        {
            tileSetSize = new Vector2(5, 9);
        }
    }
}
