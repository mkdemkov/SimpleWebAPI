using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using PeerGrade7.Models;
using System.Runtime.Serialization.Json;

namespace PeerGrade7.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за инициализацию списка пользователей и сообщений.
    /// </summary>
    [Route("[controller]")]
    public class InitializationController : Controller
    {
        private static readonly Random _rnd = new Random();
        private static readonly string _alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string[] _postfix = new string[] { "@gmail.com", "@mail.ru", "@yandex.ru", "@google.com" };

        /// <summary>
        /// Метод, заполняющий json-файлы списками пользвателей и сообщений.
        /// </summary>
        [HttpPost]
        public IActionResult InitializeUsersAndMessages()
        {
            List<User> users = GenerateUsersList();
            DataContractJsonSerializer usersSerializer = new DataContractJsonSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("users.json", FileMode.Create))
            {
                List<User> usersList = GenerateUsersList();
                usersList.Sort();
                usersSerializer.WriteObject(fs, usersList);
                users = usersList;
            }
            List<Messsage> messages = GenerateMessagesList();
            DataContractJsonSerializer messagesSerializer = new DataContractJsonSerializer(typeof(List<Messsage>));
            using (FileStream fs = new FileStream("messages.json", FileMode.Create))
            {
                List<Messsage> messagesList = GenerateMessagesList();
                messagesSerializer.WriteObject(fs, messagesList);
                messages = messagesList;
            }
            return Ok("UsersList and MessagesList are succesfully initialized!");
        }

        /// <summary>
        /// Метод, генерирующий список пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public static List<User> GenerateUsersList()
        {
            List<User> users = new List<User>();
            int userListLen = _rnd.Next(5, 30);
            for (int k = 0; k < userListLen; k++)
            {
                int emailLen = _rnd.Next(1, 10);
                string prefix = "";
                for (int i = 0; i < emailLen; i++)
                {
                    prefix += _alphabet[_rnd.Next(_alphabet.Length - 1)];
                }
                string fullEmail = prefix + _postfix[_rnd.Next(_postfix.Length - 1)];
                string userName = "";
                int userNameLen = _rnd.Next(1, 10);
                for (int i = 0; i < userNameLen; i++)
                {
                    userName += _alphabet[_rnd.Next(_alphabet.Length - 1)];
                }
                User user = new User { UserName = userName, Email = fullEmail };
                if (!users.Contains(user))
                    users.Add(user);
                else
                    userListLen++;
            }
            return users;
        }

        /// <summary>
        /// Метод, генерирующий список сообщений.
        /// </summary>
        /// <returns>Список сообщений.</returns>
        public static List<Messsage> GenerateMessagesList()
        {
            List<User> users = JsonSerialization.GetList<User>();
            List<Messsage> messages = new List<Messsage>();
            int messagesLen = _rnd.Next(5, 30);
            for (int k = 0; k < messagesLen; k++)
            {
                int subjectLen = _rnd.Next(1, 5);
                string subject = "";
                for (int s = 0; s < subjectLen; s++)
                {
                    subject += _alphabet[_rnd.Next(_alphabet.Length - 1)];
                }
                int messageLen = _rnd.Next(10, 80);
                string messageText = "";
                for (int s = 0; s < messageLen; s++)
                {
                    messageText += _alphabet[_rnd.Next(_alphabet.Length - 1)];
                }
                string senderId = users[_rnd.Next(users.Count - 1)].Email;
                string receiverId = users[_rnd.Next(users.Count - 1)].Email;
                Messsage message = new Messsage
                {
                    Subject = subject,
                    Message = messageText,
                    ReceiverId = receiverId,
                    SenderId = senderId
                };
                messages.Add(message);
            }
            return messages;
        }
    }
}
