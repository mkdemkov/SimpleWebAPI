using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using PeerGrade7.Controllers;
using PeerGrade7.Models;

namespace PeerGrade7
{
    /// <summary>
    /// Класс, отвечающий за работу с json-файлами.
    /// </summary>
    public class JsonSerialization
    {
        /// <summary>
        /// Метод, диссериализующий список пользователей/сообщений из соотвествующих json-файлов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Список пользователей/сообщений.</returns>
        public static List<T> GetList<T>()
        {
            if (typeof(T).Equals(typeof(User)))
            {
                List<T> usersList = new List<T>();
                DataContractJsonSerializer usersSerializer = new DataContractJsonSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("users.json", FileMode.Open))
                {
                    List<T> users;
                    users = usersSerializer.ReadObject(fs) as List<T>;
                    usersList = users;
                }

                return usersList;
            }
            List<T> messagesList = new List<T>();
            DataContractJsonSerializer messagesSerializer = new DataContractJsonSerializer(typeof(List<Messsage>));
            using (FileStream fs = new FileStream("messages.json", FileMode.Open))
            {
                List<T> messages;
                messages = messagesSerializer.ReadObject(fs) as List<T>;
                messagesList = messages;
            }

            return messagesList;
        }

        /// <summary>
        /// Метод, сериализующий список пользователей/сообщений в соответствующие json-файлы.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void SerializeList<T>()
        {
            if (typeof(T).Equals(typeof(User)))
            {
                DataContractJsonSerializer usersSerializer = new DataContractJsonSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("users.json", FileMode.Create))
                {
                    List<User> usersList = InitializationController.GenerateUsersList();
                    usersList.Sort();
                    usersSerializer.WriteObject(fs, usersList);
                }
            }
            else
            {
                DataContractJsonSerializer messagesSerializer = new DataContractJsonSerializer(typeof(List<Messsage>));
                using (FileStream fs = new FileStream("messages.json", FileMode.Create))
                {
                    List<Messsage> messages = InitializationController.GenerateMessagesList();
                    messagesSerializer.WriteObject(fs, messages);
                }
            }
        }
    }
}
