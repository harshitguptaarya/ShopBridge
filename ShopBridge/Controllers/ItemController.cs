#region Namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShopBridge.Interface;
using ShopBridge.Models;
using ShopBridge.Services;
using ShopBridge.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion

namespace MCNI360Advance.Controllers
{
    [Route(ShopBridge.Utilities.Routes.CONTROLLER_ROUTE)]
    [ApiController]
    public class ItemController : ControllerBase
    {
        #region Private Member

        private readonly IUnitOfWork _unitOfWork;
        private string _data;
        private ResponseDto _response;
        private readonly IItemProcessor _itemProcessor;
        private IConfiguration _configuration;

        #endregion
        public ItemController(UnitOfWork unitOfWork, IItemProcessor itemProcessor, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _itemProcessor = itemProcessor;
            _data = string.Empty;
            _response = new ResponseDto();
            _configuration = configuration;
        }

        /// <summary>
        /// Method for adding item data.
        /// </summary>
        /// <returns>It will return Json object</returns>
        [Route(ShopBridge.Utilities.Routes.ADD_ITEM)]
        [HttpPost]
        public async Task<ActionResult> AddItem([FromBody] Items model)
        {
            var error = new List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError>();
            if (ModelState.IsValid)
            {
                var data = await _itemProcessor.AddItem(_unitOfWork, model);
                _data = JsonConvert.SerializeObject(data);
            }
            else
            {
                error = ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList();
            }
            _response = MultiPurpose.ReturnResponse(_data, error);

            return Ok(_response);
        }

        /// <summary>
        /// Method for editing item data.
        /// </summary>
        /// <returns>It will return Json object</returns>
        [Route(ShopBridge.Utilities.Routes.EDIT_ITEM)]
        [HttpPut]
        public async Task<ActionResult> EditItem([FromBody] Items model)
        {
            var error = new List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError>();

            if (ModelState.IsValid)
            {
                var data = await _itemProcessor.EditItem(_unitOfWork, model);
                _data = JsonConvert.SerializeObject(data);
            }
            else
            {
                error = ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList();
            }
            _response = MultiPurpose.ReturnResponse(_data, error);

            return Ok(_response);
        }

        /// <summary>
        /// Method for deleting item data.
        /// </summary>
        /// <returns>It will return Json object</returns>
        [Route(ShopBridge.Utilities.Routes.DELETE_ITEM)]
        [HttpDelete]
        public async Task<ActionResult> DeleteItem([FromBody] int id)
        {
            var error = new List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError>();

            var data = await _itemProcessor.DeleteItem(_unitOfWork, id);
            _data = JsonConvert.SerializeObject(data);

            _response = MultiPurpose.ReturnResponse(_data, error);

            return Ok(_response);
        }

        /// <summary>
        /// Method for getting item list.
        /// </summary>
        /// <returns>It will return Json object</returns>
        [Route(ShopBridge.Utilities.Routes.GET_ITEMS)]
        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            var error = new List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError>();

            var data = await _itemProcessor.GetItems(_unitOfWork);
            _data = JsonConvert.SerializeObject(data);

            _response = MultiPurpose.ReturnResponse(_data, error);

            return Ok(_response);
        }
    }
}