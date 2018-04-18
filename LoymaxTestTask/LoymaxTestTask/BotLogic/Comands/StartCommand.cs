using LoymaxTestTask.Models.Comands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LoymaxTestTask.BotLogic.Comands
{
    public class StartCommand : Command
    {
        public override string Name => "/start";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(chatId, "Введите свое ФИО и дату рождения в формате дд.мм.гггг через пробел/n Пример: /add Фамилия Имя Отчество 20.02.2000" , replyToMessageId: messageId);;
        }
    }
}