using Exiled.API.Interfaces;
using System.ComponentModel;
using Exiled.CustomItems.API;

namespace Nukacola
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Item Config")]
        public float SpawnChance { get; set; } = 50;
        public float MovementBoostEffectDuration { get; set; } = 80;
        public float VitalityEffectDuration { get; set; } = 20;
        public float HintsDuration { get; set; } = 5;
        public uint ItemID { get; set; } = 20;
        public float ItemWeight { get; set; } = 1;
        public string ItemDescription { get; set; } = "Empower yourself by taking this nukacola!!";
        public SpawnLocation SpawnLocation { get; set; } = SpawnLocation.InsideHid;
        public string DroppedHint { get; set; } = "You dropped the Nukacola";
        public string UsedHint { get; set; } = "You used the Nukacola";
        public string TakenHint { get; set; } = "You taken the Nukacola";
        public float Heal { get; set; } = 150f;
        public bool OverrideMaxHealth { get; set; } = true;
    }
}
