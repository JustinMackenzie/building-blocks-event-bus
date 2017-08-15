using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RawRabbit.Common;
using RawRabbit.Serialization;

namespace EventBus.RawRabbit
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="RawRabbit.Serialization.IMessageSerializer" />
    public class TypelessJsonSerializer : IMessageSerializer
    {
        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public byte[] Serialize<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return Encoding.ASCII.GetBytes(json);
        }

        /// <summary>
        /// Deserializes the specified bytes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes">The bytes.</param>
        /// <returns></returns>
        public T Deserialize<T>(byte[] bytes)
        {
            string json = Encoding.ASCII.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Deserializes the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <returns></returns>
        public object Deserialize(byte[] bytes, Type messageType)
        {
            string json = Encoding.ASCII.GetString(bytes);
            return JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// Deserializes the specified arguments.
        /// </summary>
        /// <param name="args">The <see cref="BasicDeliverEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        public object Deserialize(BasicDeliverEventArgs args)
        {
            object typeBytes;
            if (args.BasicProperties.Headers.TryGetValue(PropertyHeaders.MessageType, out typeBytes))
            {
                var typeName = Encoding.UTF8.GetString(typeBytes as byte[] ?? new byte[0]);
                var type = Type.GetType(typeName, false);
                return Deserialize(args.Body, type);
            }
            else
            {
                var typeName = args.BasicProperties.Type;
                var type = Type.GetType(typeName, false);
                return Deserialize(args.Body, type);
            }
        }
    }
}
