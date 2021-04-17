#region Namespace

using Dapper;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

#endregion

namespace ShopBridge.Utilities
{
    /// <summary>
    /// This class has methods to be used across the application.
    /// </summary>
    public static class MultiPurpose
    {
        #region Public Member

        /// <summary>
        /// This method is used to return a response data transfer object
        /// </summary>
        /// <param name="data">Serialized data to be sent as response</param>
        /// <returns>Object of ResponseDto</returns>
        public static ResponseDto ReturnResponse(string data, List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelError> error)
        {
            var response = new ResponseDto
            {
                Code = error.Count > 0 ? Common.ERROR_CODE : Common.SUCCESS_CODE,
                Data = new Data
                {
                    Response = new Response()
                    {
                        ReasonCode = error.Count > 0 ? Common.FAIL_VAL : Common.SUCCESS_VAL,
                        ReasonText = error.Count > 0 ? Common.FAIL : Common.SUCCESS,
                        DataList = data,
                        Error = string.Join("; ", error)
                    }
                }
            };

            return response;
        }
                 
        /// <summary>
        /// This method is used to add sql parameters
        /// </summary>
        /// <param name="param">String array of parameter names</param>
        /// <param name="columns">Object array of Values of parameters</param>
        /// <returns>Dynamic Parameters object</returns>
        public static DynamicParameters AddParameters(string[] param, object[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            var parameter = new DynamicParameters();
            var idx = 0;
            foreach (var item in param)
            {
                parameter.Add(item, columns[idx]);
                idx++;
            }
            return parameter;
        }
              
        
        #endregion
    }    
}
