using LoymaxTestTask.BotLogic.Comands;
using LoymaxTestTask.Models.Comands;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace LoymaxTestTask.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new AddCommand());
            commandsList.Add(new GetInfoCommand());
            commandsList.Add(new RemovePersoneCommand());
            commandsList.Add(new StartCommand());

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/values/update1");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}