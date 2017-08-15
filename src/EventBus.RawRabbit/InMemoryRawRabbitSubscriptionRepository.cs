using System.Collections.Generic;
using RawRabbit.Common;

namespace EventBus.RawRabbit
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="EventBus.RawRabbit.IRawRabbitSubscriptionRepository" />
    public class InMemoryRawRabbitSubscriptionRepository : IRawRabbitSubscriptionRepository
    {
        /// <summary>
        /// The subscriptions
        /// </summary>
        private readonly List<ISubscription> _subscriptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryRawRabbitSubscriptionRepository"/> class.
        /// </summary>
        public InMemoryRawRabbitSubscriptionRepository()
        {
            this._subscriptions = new List<ISubscription>();
        }

        /// <summary>
        /// Adds the specified subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        public void Add(ISubscription subscription)
        {
            this._subscriptions.Add(subscription);
        }
    }
}