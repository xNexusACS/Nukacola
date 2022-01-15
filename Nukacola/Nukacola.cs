using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;

namespace Nukacola
{
    public class Nukacola : CustomItem
    {
        public override uint Id { get; set; } = 20;
        public override string Name { get; set; } = "Nukacola";
        public override string Description { get; set; } = "Empower yourself by taking this nukacola!!";
        public override float Weight { get; set; } = 1f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.SpawnChance,
                    Location = SpawnLocation.InsideHid,
                }
            }
        };
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.DroppingItem += OnDropping;
            Exiled.Events.Handlers.Player.UsingItem += OnUsedItem;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPickingUp;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropping;
            Exiled.Events.Handlers.Player.ItemUsed -= OnUsedItem;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUp;
        }
        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                base.OnDropping(ev);
                ev.Player.ShowHint("You dropped the Nukacola", Plugin.Singleton.Config.HintsDuration);
            }
        }
        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                ev.Player.EnableEffect(EffectType.MovementBoost, Plugin.Singleton.Config.MovementBoostEffectDuration);
                ev.Player.EnableEffect(EffectType.Vitality, Plugin.Singleton.Config.VitalityEffectDuration);
                ev.Player.ShowHint("You used the Nukacola", Plugin.Singleton.Config.HintsDuration);
                ev.Player.Heal(200, overrideMaxHealth: true);
            }
        }
        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            if (Check(ev.Pickup))
            {
                base.OnPickingUp(ev);
                ev.Player.ShowHint("You taken the Nukacola", Plugin.Singleton.Config.HintsDuration);
            }
        }
    }
}
