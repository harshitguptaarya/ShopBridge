#region NameSpace

using ShopBridge.Interface;
using ShopBridge.Models;
using ShopBridge.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion
namespace ShopBridge.Services
{
    public class ItemProcessor : IItemProcessor
    {
        #region Private Member

        private string[] _param;
        private object[] _columns;

        #endregion

        #region Public Methods
        /// <summary>
        /// This method is used to save item data.
        /// </summary>
        /// <param name="unitOfWork">Object for Unit Of Work</param>
        /// <param name="model">Item model</param>
        /// <returns>It will return list of object</returns>
        public async Task<int> AddItem(IUnitOfWork unitOfWork, Items model)
        {
            _param = new[] { SQLParameters.NAME, SQLParameters.DESCRIPRION, SQLParameters.PRICE };
            _columns = new object[] { model.Name, model.Descriprion, model.Price };
            var parameter = MultiPurpose.AddParameters(_param, _columns);
            var result = unitOfWork.StoredProcedureCall.Single<int>(ProcedureNames.SAVE_ITEM_DATA, parameter);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// This method is used to edit item data.
        /// </summary>
        /// <param name="unitOfWork">Object for Unit Of Work</param>
        /// <param name="model">Item model</param>
        /// <returns>It will return list of object</returns>
        public async Task<int> EditItem(IUnitOfWork unitOfWork, Items model)
        {
            _param = new[] {  SQLParameters.ID, SQLParameters.NAME, SQLParameters.DESCRIPRION, SQLParameters.PRICE };
            _columns = new object[] { model.Id, model.Name, model.Descriprion, model.Price };
            var parameter = MultiPurpose.AddParameters(_param, _columns);
            var result = unitOfWork.StoredProcedureCall.Single<int>(ProcedureNames.EDIT_ITEM_DATA, parameter);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// This method is used to delete item data.
        /// </summary>
        /// <param name="unitOfWork">Object for Unit Of Work</param>
        /// <param name="model">Item model</param>
        /// <returns>It will return list of object</returns>
        public async Task<int> DeleteItem(IUnitOfWork unitOfWork, int id)
        {
            _param = new[] { SQLParameters.ID };
            _columns = new object[] { id };
            var parameter = MultiPurpose.AddParameters(_param, _columns);
            var result = unitOfWork.StoredProcedureCall.Single<int>(ProcedureNames.DELETE_ITEM_DATA, parameter);
            return await Task.FromResult(result);
        }

        /// <summary>
        /// This method is used to get item list.
        /// </summary>
        /// <param name="unitOfWork">Object for Unit Of Work</param>
        /// <param name="model">Device model</param>
        /// <returns>It will return list of object</returns>
        public async Task<IEnumerable<Items>> GetItems(IUnitOfWork unitOfWork)
        {
            var result = unitOfWork.StoredProcedureCall.List<Items>(ProcedureNames.GET_ITEM_LIST);
            return await Task.FromResult(result);
        }
        #endregion

    }
}
