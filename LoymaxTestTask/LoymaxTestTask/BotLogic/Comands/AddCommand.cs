using LoymaxTestTask.Models;
using LoymaxTestTask.Models.Comands;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LoymaxTestTask.BotLogic.Comands
{
    public class AddCommand : Command
    {
        public int StartMessageId { get; set; }
        public long StartChatId { get; set; }
        public bool Registration { get; set; }

        public override string Name => "/add";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            string result = "";
            using (PersonContext context = new PersonContext())
            {
                try
                {
                    if (message.Text != null)
                    {
                        string[] Data = message.Text.Split(' ');
                        Data = Data.Where(x => x != "").ToArray();
                        DateTime birthday = DateTime.Parse(Data[4]);
                        Person person = context.Persons.ToList().Find(x => x.chatId == chatId);

                        if (person == null)
                        {
                            Person pers = new Person() { Surname = Data[1], Name = Data[2], Patronymic = Data[3], Birthday = birthday, chatId = chatId };
                            context.Persons.Add(pers);
                            context.SaveChanges();
                            result = " Регистрация прошла успешно! ";
                        }
                        else
                        {
                            result = "Вы уже зарегестрировались.";
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {

                    result = " Вы ввели не все данные. Попробуйте еще раз.";

                }
                catch (FormatException ex)
                {
                    result = " Вы неправильно ввели дату рождения. Попробуйте еще раз.";
                }
                catch (Exception ex)
                {
                    result = "Message " + ex.Message + " HelpLink " + ex.HelpLink + " Source " + ex.Source + " TargetSite " + ex.TargetSite.ToString();
                }
                finally
                {
                    client.SendTextMessageAsync(chatId, result, replyToMessageId: messageId);
                }
            }
            
        }

    }
}