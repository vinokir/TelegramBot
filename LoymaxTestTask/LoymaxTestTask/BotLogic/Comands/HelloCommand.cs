using Telegram.Bot;
using Telegram.Bot.Types;

namespace LoymaxTestTask.Models.Comands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(chatId, "It works", replyToMessageId: messageId);
        }
    }
}