using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using PeerGrade7.Models;

namespace PeerGrade7.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за работу с сообщениями.
    /// </summary>
    [Route("[controller]")]
    public class MessageController : Controller
    {
        /// <summary>
        /// Метод, которые ищет все сообщения, отправленные от пользователя с Email senderId
        /// пользователю с Email receiverId.
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="receiverId"></param>
        /// <returns>Возвращает либо сообщение об ошибке, либо статус успешного выполнения со
        /// списком сообщений.</returns>
        [HttpGet("{senderId}/{receiverId}")]
        public IActionResult GetMessagesListByIds(string senderId, string receiverId)
        {
            try
            {
                List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();

                if (messagesList is null)
                    return BadRequest("MessagesList is empty! Initialize it before calling this method.");

                bool status = FindMessagesByBothId(senderId, receiverId).Item1;
                List<Messsage> messages = FindMessagesByBothId(senderId, receiverId).Item2;
                if (!status)
                    return NotFound("Messages with these identificators not found.");

                return Ok(messages);
            }
            catch
            {
                return BadRequest("MessagesList is empty! Initialize it before calling this method.");
            }
        }

        /// <summary>
        /// Метод, который непосредственно ищет сообщения, отправленные от пользователя с Email senderId
        /// пользователю с Email receiverId.
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="receiverId"></param>
        /// <returns>Возвращает статус false, если сообщения не нашлись и пустой список, либо
        /// статус true и список найденных сообщений.</returns>
        private (bool, List<Messsage>) FindMessagesByBothId(string senderId, string receiverId)
        {
            List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();

            List<Messsage> messages = new List<Messsage>();
            foreach (var message in messagesList)
            {
                if (message.ReceiverId.Equals(receiverId) && message.SenderId.Equals(senderId))
                {
                    messages.Add(message);
                }
            }

            if (messages.Count == 0)
                return (false, null);

            return (true, messages);
        }

        /// <summary>
        /// Метод, которые ищет все сообщения, отправленные от пользователя с Email senderId.
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns>Возвращает либо сообщение об ошибке, либо статус успешного выполнения со
        /// списком сообщений.</returns>
        [HttpGet("GetMessagesBySenderId, {senderId}")]
        public IActionResult GetMessagesBySenderId(string senderId)
        {
            try
            {
                List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();

                if (messagesList is null)
                    return BadRequest("MessagesList is empty! Initialize it before calling this method.");

                bool status = FindMessagesBySenderId(senderId).Item1;
                List<Messsage> messages = FindMessagesBySenderId(senderId).Item2;
                if (!status)
                    return NotFound("Messages with this SenderId not found.");

                return Ok(messages);
            }
            catch
            {
                return BadRequest("MessagesList is empty! Initialize it before calling this method.");
            }
        }

        /// <summary>
        /// Метод, который непосредственно ищет сообщения, отправленные от пользователя с Email senderId.
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns>Возвращает статус false, если сообщения не нашлись и пустой список, либо
        /// статус true и список найденных сообщений.</returns>
        private (bool, List<Messsage>) FindMessagesBySenderId(string senderId)
        {
            List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();
            List<Messsage> messages = new List<Messsage>();
            foreach (var message in messagesList)
            {
                if (message.SenderId.Equals(senderId))
                {
                    messages.Add(message);
                }
            }

            if (messages.Count == 0)
                return (false, null);

            return (true, messages);
        }

        /// <summary>
        /// Метод, которые ищет все сообщения, отправленные пользователю с Email receiverId.
        /// </summary>
        /// <param name="receiverId"></param>
        /// <returns>Возвращает либо сообщение об ошибке, либо статус успешного выполнения со
        /// списком сообщений.</returns>
        [HttpGet("GetMessagesByReceiverId, {receiverId}")]
        public IActionResult GetMessagesByReceiverId(string receiverId)
        {
            try
            {
                List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();

                if (messagesList is null)
                    return BadRequest("MessagesList is empty! Initialize it before calling this method.");

                bool status = FindMessagesByReceiverId(receiverId).Item1;
                List<Messsage> messages = FindMessagesByReceiverId(receiverId).Item2;
                if (!status)
                    return NotFound("Messages with this ReceiverId not found.");

                return Ok(messages);
            }
            catch
            {
                return BadRequest("MessagesList is empty! Initialize it before calling this method.");
            }
        }

        /// <summary>
        /// Метод, который непосредственно ищет сообщения, отправленные пользователю с Email receiverId.
        /// </summary>
        /// <param name="receiverId"></param>
        /// <returns>Возвращает статус false, если сообщения не нашлись и пустой список, либо
        /// статус true и список найденных сообщений.</returns>
        private (bool, List<Messsage>) FindMessagesByReceiverId(string receiverId)
        {
            List<Messsage> messagesList = JsonSerialization.GetList<Messsage>();
            List<Messsage> messages = new List<Messsage>();
            foreach (var message in messagesList)
            {
                if (message.ReceiverId.Equals(receiverId))
                {
                    messages.Add(message);
                }
            }

            if (messages.Count == 0)
                return (false, null);

            return (true, messages);
        }
    }
}
