using System;
using System.Text;

namespace SendEmailandSMSConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Відправка повідомлення novakvova@gmail.com!");
            SmtpEmailService emailService = new SmtpEmailService();
            Message message = new Message();
            message.Subject = "Закупляємо альтернативні джерела енергії";
            message.Body = "Беріть гернератори, інвертери або свічки і усе буде круто";
            message.To = "novakvova@gmail.com";
            emailService.Send(message);
        }
    }
}
