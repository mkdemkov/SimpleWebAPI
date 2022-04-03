using System.Runtime.Serialization;
using System;

namespace PeerGrade7.Models
{
    /// <summary>
    /// Класс пользователя.
    /// </summary>
    [DataContract, KnownType(typeof(User))]
    public class User : IComparable
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [DataMember] public string UserName { get; set; }

        /// <summary>
        /// Email пользователя.
        /// </summary>
        [DataMember] public string Email { get; set; }

        /// <summary>
        /// Метод, отвечающий за сортировку пользователей по Email.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает результат сравнения Email-ов.</returns>
        public int CompareTo(object obj)
        {
            User user = obj as User;
            return Email.CompareTo(user.Email);
        }

        /// <summary>
        /// Переопределенный метод Equals, чтобы проверять, является ли Email уникальным.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает true, если Email совпадают, иначе false.</returns>
        public override bool Equals(object obj)
        {
            User user = obj as User;
            if (user.Email.Equals(Email))
                return true;

            return false;
        }

        /// <summary>
        /// Переопределенный GetHashCode(без него не робит Equals).
        /// </summary>
        /// <returns>Хэш код.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
