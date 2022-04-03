using System.Runtime.Serialization;

namespace PeerGrade7.Models
{
    /// <summary>
    /// Класс сообщений.
    /// </summary>
    [DataContract, KnownType(typeof(Messsage))]
    public class Messsage
    {
        /// <summary>
        /// Тема сообщения.
        /// </summary>
        [DataMember] public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения.
        /// </summary>
        [DataMember] public string Message { get; set; }

        /// <summary>
        /// Email отправителя сообщения.
        /// </summary>
        [DataMember] public string SenderId { get; set; }

        /// <summary>
        /// Email получателя сообщения.
        /// </summary>
        [DataMember] public string ReceiverId { get; set; }

    }
}
