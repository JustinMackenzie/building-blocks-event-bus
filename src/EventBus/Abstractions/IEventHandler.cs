using System.Threading.Tasks;
using BuildingBlocks.EventBus.Events;

namespace BuildingBlocks.EventBus.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventHandler" />
    public interface IEventHandler<in TEvent> : IEventHandler 
        where TEvent: Event
    {
        /// <summary>
        /// Handles the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        Task Handle(TEvent @event);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuildingBlocks.EventBus.Abstractions.IEventHandler" />
    public interface IEventHandler
    {
    }
}
