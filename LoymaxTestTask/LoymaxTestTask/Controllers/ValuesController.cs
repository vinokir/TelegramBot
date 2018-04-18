using LoymaxTestTask.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;

namespace LoymaxTestTask.Controllers
{
    public class ValuesController : ApiController
    {
        

        [Route(@"api/values/update1")] 
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            if (message.Text != null)
            {
                 string[] Data = message.Text.Split(' ');

                 foreach (var command in commands)
                    {
                        if (command.Contains(Data[0]))
                        {
                            command.Execute(message, client);
                            break;
                        }
                    }
            }

            return Ok();
        }
    }
}
