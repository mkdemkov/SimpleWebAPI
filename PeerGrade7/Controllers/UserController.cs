using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PeerGrade7.Models;
using System.Runtime.Serialization.Json;
using System.IO;
using System;

namespace PeerGrade7.Controllers
{
    /// <summary>
    /// Контроллер, отвечающий за работу с пользователями.
    /// </summary>
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Метод, по которому можно получить список всех пользователей(упорядоченный согласно спецификации).
        /// </summary>
        /// <returns>Возвращает либо сообщение об ошибке, либо статус успешного выполнения
        /// со списком пользлвателей.</returns>
        [HttpGet]
        public IActionResult GetUsersList()
        {
            try
            {
                List<User> users = JsonSerialization.GetList<User>();
                if (users is null)
                    return BadRequest("UsersList is Empty! Initialize it before calling this method.");
                return Ok(users);
            }
            catch
            {
                return BadRequest("UsersList is Empty! Initialize it before calling this method.");
            }
        }

        /// <summary>
        /// Метод, возвращающий информацию о пользователе с указанным Id(Email).
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Возвращает либо сообщение об ошибке, либо статус успешного выполнения
        /// с нужным пользователем.</returns>
        [HttpGet("GetUserById, {email}")]
        public IActionResult GetUserById(string email)
        {
            try
            {
                List<User> users = JsonSerialization.GetList<User>();

                if (users is null)
                    return BadRequest("UsersList is Empty! Initialize it before calling this method.");

                var user = users.SingleOrDefault(x => x.Email == email);
                if (user is null)
                    return NotFound("Can't find user with this id.");

                return Ok(user);
            }
            catch
            {
                return BadRequest("UserList is Empty! Initialize it before calling this method.");
            }
        }

        /// <summary>
        /// Метод, добавляющий в систему нового пользователя.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Email"></param>
        /// <returns>Статус успешного выполнения либо сообщение об ошибке.</returns>
        [HttpPost("{UserName}/{Email}")]
        public IActionResult AddNewUser(string UserName, string Email)
        {
            string prefixes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] postfixes = new string[] { "@gmail.com", "@mail.ru", "@yandex.ru", "@google.com" };
            foreach (char symbol in UserName)
            {
                if (!prefixes.Contains(symbol))
                {
                    return BadRequest("You can only use English alphabet in UserName(capital and small letters)");
                }
            }
            string prefix = "";
            string postfix = "";
            for (int i = 0; i < Email.Length; i++)
            {
                char symbol = Email[i];
                int index = i;
                if (symbol.CompareTo('@') is 0)
                {
                    for (int j = index; j < Email.Length; j++)
                        postfix += Email[j];
                    break;
                }
                prefix += symbol;
            }

            foreach (char symbol in prefix)
            {
                if (!prefixes.Contains(symbol))
                    return BadRequest("You can only use English alphabet(capital and small letters) in Email(before @***.***)");
            }
            if (!postfixes.Contains(postfix))
                return BadRequest("User Email should ends on one of there postfixes: @gmail.com, @mail.ru, @yandex.ru, @google.com");   
            
            User user = new User { UserName = UserName, Email = Email };
            DataContractJsonSerializer usersSerializer = new DataContractJsonSerializer(typeof(List<User>));
            using (FileStream fs = new FileStream("users.json", FileMode.Create))
            {
                List<User> usersList = InitializationController.GenerateUsersList();
                usersList.Add(user);
                usersList.Sort();
                usersSerializer.WriteObject(fs, usersList);
            }
            return Ok("User succesfully Added!");
        }
    }
}


