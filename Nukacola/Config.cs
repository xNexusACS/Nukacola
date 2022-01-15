using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Nukacola
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Item Config")]
        public float SpawnChance { get; set; } = 50;
    }
}
