namespace Oxide.Plugins
{
    [Info("Filter FWords", "YUJA", "1.0.0")]
    [Description("Filtering FWords!! by YUJA(https://yuja.io/)")]
    class FilterFWords : RustPlugin
    {
        public var source = new string[] {"시발", "병신", "느금", "니애미", "비번"};
        // private object OnServerMessage(string message, string name, string color, ulong playerId)
        // {
        //     if (source.Any(data => message.Contains(data)))
        //     {
        //         Puts($"{playerName} ({playerId}) Actavated Filter: {message}");
        //         return true;
        //     }

        //     return null;
        // }

        private object OnPlayerChat(BasePlayer player, string message, Chat.ChatChannel channel) 
        {
            if (source.Any(data => message.Contains(data)))
            {
                Puts($"{player.Name}({player.Id}) Actavated Filter: {message}");
                player.Reply($"Filter Actavated! by {message}");
                webrequest.Enqueue("http://www.google.com/search?q=umod", $"content={player.Name}({player.Id}) Actavated Filter: {message}", (code, response) =>
                {
                    if (code != 200 || response == null)
                    {
                        Puts($"Failed to Send Webhook!");
                        return;
                    }
                    Puts($"Return: {response}");
                }, this, RequestMethod.POST);
                return true;
            }

            return null;
        }
    }
}
