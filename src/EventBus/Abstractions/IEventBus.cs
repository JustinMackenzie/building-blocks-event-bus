using System;
using BuildingBlocks.EventBus.Events;

namespace BuildingBlocks.EventBus.Abstractions
{
    /// <summary>
    /// Represents a generic event bus interface that can be used to subscribe
    /// to events and publish events.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Subscribes the specified handler.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <typeparam name="THandler">The type of the handler.</typeparam>
        /// <param name="handler">The handler.</param>
        void Subscribe<TEvent, THandler>(Func<THandler> handler)
            where TEvent : Event
            where THandler : IEventHandler<TEvent>;

        /// <summary>
        /// Unsubscribes this instance.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <typeparam name="THandler">The type of the handler.</typeparam>
        void Unsubscribe<TEvent, THandler>()
            where THandler : IEventHandler<TEvent>
            where TEvent : Event;

        /// <summary>
        /// Publishes the specified event.
        /// </summary>
        /// <param name="event">The event.</param>
        void Publish(Event @event);
    }
}
