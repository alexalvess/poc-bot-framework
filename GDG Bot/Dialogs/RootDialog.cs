using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace GDG_Bot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        /// <summary>
        /// Fica aguardando sempre uma mensagem digitada 
        /// por algum membro
        /// </summary>
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }


        /// <summary>
        /// Realiza todas as tratativas com base na mensagem recebida
        /// </summary>
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if (activity.Text.Equals("Bom dia", StringComparison.InvariantCultureIgnoreCase) ||
               activity.Text.Equals("Boa tarde", StringComparison.InvariantCultureIgnoreCase) ||
               activity.Text.Equals("Boa noite", StringComparison.InvariantCultureIgnoreCase))
                await context.PostAsync($"Bem vindo ao GDG de Divinópolis! :)");
            else
                await context.PostAsync("Desculpe, não consegui entender sua mensagem. :(");

            context.Wait(MessageReceivedAsync);
        }



        /// <summary>
        /// Realiza todas as tratativas com base na mensagem recebida
        /// </summary>
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if (activity.Text.Equals("Bom dia", StringComparison.InvariantCultureIgnoreCase) ||
               activity.Text.Equals("Boa tarde", StringComparison.InvariantCultureIgnoreCase) ||
               activity.Text.Equals("Boa noite", StringComparison.InvariantCultureIgnoreCase))
            {
                var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")).TimeOfDay;
                string saudacao = string.Empty;

                if (now < TimeSpan.FromHours(12))
                    saudacao = "Bom dia!";
                else if (now < TimeSpan.FromHours(18))
                    saudacao = "Boa tarde!";
                else
                    saudacao = "Boa noite!";

                await context.PostAsync($"{saudacao} Bem vindo ao GDG de Divinópolis! :)");
            }
            else
                await context.PostAsync("Desculpe, não consegui entender sua mensagem. :(");

            context.Wait(MessageReceivedAsync);
        }
    }
}