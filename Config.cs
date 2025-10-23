using Exiled.API.Interfaces;

namespace broadcast_plugin
{
    public class Config : IConfig
    {
        public string on_join_message { get; set; } = "Welcome to the server {player}!";
        public string on_died_message { get; set; } = "You have died. Better luck next time!";
        public string persistent_hint_text { get; set; } = "Powered by Broadcast Plugin by Naleśnior";
        public ushort Broadcast_Duration { get; set; } = 3;
        public float Hint_Duration { get; set; } = 1.5f;
        public int HintVerticalPosition { get; set; } = 20;
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
    }
}