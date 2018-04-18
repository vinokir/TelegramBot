using LoymaxTestTask.Models;
using LoymaxTestTask.Models.Comands;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LoymaxTestTask.BotLogic.Comands
{
    public class RemovePersoneCommand : Command
    {
        public override string Name => "/remove";

        public override void Execute(Message message, TelegramBotClient client)
        {
            using (PersonContext context = new PersonContext())
            {
                var chatId = message.Chat.Id;
                var messageId = message.MessageId;
                string result = "";
                try
                {
                    Person person = context.Persons.ToList().Find(x => x.chatId == chatId);
                    if (person != null)
                    {
                        context.Persons.Remove(person);
                        context.SaveChanges();
                        result = " Запись удалена. ";
                    }
                    else result = "Вы не зарегестрировались.";


                }

                catch (Exception ex)
                {
                    result = ex.Message;
                }
                finally
                {
                    client.SendTextMessageAsync(chatId, result, replyToMessageId: messageId);
                }
            }
           
        }
    }
}