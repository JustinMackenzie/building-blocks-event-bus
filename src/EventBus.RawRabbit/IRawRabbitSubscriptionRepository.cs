using RawRabbit.Common;

namespace EventBus.RawRabbit
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRawRabbitSubscriptionRepository
    {
        /// <summary>
        /// Adds the specified subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        void Add(ISubscription subscription);
    }
}