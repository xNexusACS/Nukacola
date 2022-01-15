using System;
using Exiled.API.Features;

namespace Nukacola
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Singleton;
        public override string Name { get; } = "NukaCola";
        public override string Prefix { get; } = "nukacola";
        public override string Author { get; } = "xNexus-ACS";
        public override Version Version { get; } = new Version(0, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(4, 2, 2);

        public Nukacola nukacola;

        public override void OnEnabled()
        {
            Log.Info("Nukacola Loaded, new Item!!");

            NukaCola();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }
        public void NukaCola()
        {
            nukacola = new Nukacola { Type = ItemType.SCP207 };
            nukacola.TryRegister();
        }
    }
}
