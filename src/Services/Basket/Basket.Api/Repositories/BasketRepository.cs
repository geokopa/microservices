using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            await _redisCache.RemoveAsync(userName, cancellationToken);
        }

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await _redisCache.GetStringAsync(userName, cancellationToken);

            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken token = default)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket), token);

            return await GetBasket(basket.UserName, token);
        }
    }
}
