using LangingPage.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace LangingPage.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoDTO contactoDTO);
    }

    public class ServicioEmailSendGrid: IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoDTO contactoDTO)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            
            //Email de salida
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            //Nombre de quien manda el mensaje
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El Cliente {contactoDTO.Email} quiere contactarte";
            //Email al que va dirijido el mensaje (Nosotros)
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contactoDTO.Mensaje;
            //Version html del mensaje
            var ContenidoHtml = @$"De: {contactoDTO.Nombre} -
                                  Email: {contactoDTO.Email} 
                                  Mensaje: {contactoDTO.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, ContenidoHtml);

            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }

    }
}
