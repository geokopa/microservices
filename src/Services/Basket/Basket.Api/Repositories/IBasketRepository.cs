using Basket.Api.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
        Task DeleteBasket(string userName, CancellationToken cancellationToken = default);
    }
}
