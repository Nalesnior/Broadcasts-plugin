using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace broadcast_plugin
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }
        private CoroutineHandle hintCoroutine;

        public override string Name => "Broadcast Plugin";
        public override string Author => "Naleśnior";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(9, 6, 1);

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
            Log.Info("Broadcast Plugin has been enabled.");
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            if (hintCoroutine.IsRunning)
                Timing.KillCoroutines(hintCoroutine);
            Instance = null;
            base.OnDisabled();
            Log.Info("Broadcast Plugin has been disabled.");
        }

        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Player.Verified += OnPlayerJoin;
            Exiled.Events.Handlers.Player.Died += OnPlayerDied;
        }

        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Player.Verified -= OnPlayerJoin;
            Exiled.Events.Handlers.Player.Died -= OnPlayerDied;
        }

        private void OnPlayerJoin(VerifiedEventArgs ev)
        {
            ev.Player.Broadcast(new Exiled.API.Features.Broadcast(Config.on_join_message.Replace("{player}", ev.Player.Nickname), Config.Broadcast_Duration));
        }

        private void OnPlayerDied(DiedEventArgs ev)
        {
            ev.Player.Broadcast(new Exiled.API.Features.Broadcast(Config.on_died_message, Config.Broadcast_Duration));
        }
    }
}