using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using System.Collections.Generic;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;

namespace Nukacola
{
    [CustomItem(ItemType.SCP207)]
    public class Nukacola : CustomItem
    {
        public override uint Id { get; set; } = Plugin.Singleton.Config.ItemID;
        public override string Name { get; set; } = "Nukacola";
        public override string Description { get; set; } = Plugin.Singleton.Config.ItemDescription;
        public override float Weight { get; set; } = Plugin.Singleton.Config.ItemWeight;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = Plugin.Singleton.Config.SpawnChance,
                    Location = Plugin.Singleton.Config.SpawnLocation
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
            Exiled.Events.Handlers.Player.UsedItem -= OnUsedItem;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPickingUp;
        }
        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                base.OnDropping(ev);
                ev.Player.ShowHint(Plugin.Singleton.Config.DroppedHint, Plugin.Singleton.Config.HintsDuration);
            }
        }
        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                ev.Player.EnableEffect(EffectType.MovementBoost, Plugin.Singleton.Config.MovementBoostEffectDuration);
                ev.Player.EnableEffect(EffectType.Vitality, Plugin.Singleton.Config.VitalityEffectDuration);
                ev.Player.DisableEffect(EffectType.Scp207);
                ev.Player.ShowHint(Plugin.Singleton.Config.UsedHint, Plugin.Singleton.Config.HintsDuration);
                ev.Player.Heal(Plugin.Singleton.Config.Heal, overrideMaxHealth: Plugin.Singleton.Config.OverrideMaxHealth);
                ev.Player.MaxHealth = 200;
                ev.Item.MaxCancellableTime = 0;
            }
        }
        protected override void OnPickingUp(PickingUpItemEventArgs ev)
        {
            if (Check(ev.Pickup))
            {
                base.OnPickingUp(ev);
                ev.Player.ShowHint(Plugin.Singleton.Config.TakenHint, Plugin.Singleton.Config.HintsDuration);
            }
        }
    }
}
