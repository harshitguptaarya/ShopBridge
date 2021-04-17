#region Namespace

using ShopBridge.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace ShopBridge.Interface
{
    public interface IItemProcessor
    {
        Task<int> AddItem(IUnitOfWork unitOfWork, Items model);
        Task<int> EditItem(IUnitOfWork unitOfWork, Items model);
        Task<int> DeleteItem(IUnitOfWork unitOfWork, int id);
        Task<IEnumerable<Items>> GetItems(IUnitOfWork unitOfWork);
    }
}
