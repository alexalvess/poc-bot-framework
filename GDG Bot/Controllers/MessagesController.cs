using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace GDG_Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Rebece as mensagens do usuário e o responde
        /// </summary>
        /// <param name="activity">Contém todas as informações do usuário que envia a mensagem</param>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            // Identifica que o usuário mandou uma mensagem,
            // não necessariamente texto, podendo ser arquivo, anexo.
            // Com isso, cria-se um diálogo
            if (activity.Type == ActivityTypes.Message)
                await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());

            // Se não for do tipo mensagem, verifica qual é o tipo
            // e realiza algum tratamento específico
            else
                HandleSystemMessage(activity);

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // O usuário não faz este tipo de operação
                // são os gerenciamentos do próprio framework que
                // dispara este tipo de mensagem, para saber que houve
                // algum tipo de informação do usuário que foi removida
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // A conversação foi atualizada, significando que
                // durante a conversa o usuário ou o bot adicionou ou removeu
                // algum outro usuário ou algum outro bot
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Durante a conversação foi adicionado ou removido
                // algum membro referente a sua lista de contatos
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Similar ao status do whatsapp, quando o usuário
                // está digitando ou gravando algum áudio
            }
            else if (message.Type == ActivityTypes.Ping)
            {
                // Envio de bits para os end-points para
                // saber se tudo está ok, se tudo está no on
            }

            return null;
        }
    }
}


