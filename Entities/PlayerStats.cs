using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mg_Project_03.Entities
{
    public class PlayerStats
    {

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Health")]
        public double Health { get; set; }
    }
}
