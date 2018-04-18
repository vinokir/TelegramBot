using LoymaxTestTask.Models;
using LoymaxTestTask.Models.Comands;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LoymaxTestTask.BotLogic.Comands
{
    public class GetInfoCommand : Command
    {
        public override string Name => "/getinfo";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string str = "";
            using (PersonContext context = new PersonContext())
            {
                try
                {
                    Person person = context.Persons.ToList().Find(x => x.chatId == chatId);
                    context.SaveChanges();
                    if (person != null)
                    {
                        str = person.Surname + ' ' + person.Name + ' ' + person.Patronymic + ' ' + person.Birthday.ToString("dd.MM.yyyy");
                    }
                    else str = "Вы не зарегестрировались.";
                }
                catch (Exception ex) { str = ex.Message; }
                finally { client.SendTextMessageAsync(chatId, str, replyToMessageId: messageId); }
            }


        }
    }
}