#region Namespace

using Dapper;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
#endregion

namespace ShopBridge.Interface
{
    /// <inheritdoc />
    /// <summary>
    /// This class is responsible to handle all the stored procedure calls 
    /// </summary>
    public class StoredProcedureCall : IStoredProcedureCall
    {        
        #region Private Member

        private MySettings Db { get; set; }
        private SqlConnection _sqlConn;
        
        #endregion

        #region Constructor

        public StoredProcedureCall(MySettings options)
        {
            Db = options;
            _sqlConn = new SqlConnection(Db.ConnectionString);
        }

        #endregion
        
        #region Public Methods 
        
        /// <summary>
        /// This method is used to execute Stored Procedure and return the records
        /// </summary>
        /// <param name="procedureName">Name of the StoredProcedure to be executed </param>
        /// <param name="param">Parameter list to be supplied to SP </param>
        /// <returns>An IEnumerable object of data </returns>
        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (_sqlConn = new SqlConnection(Db.ConnectionString))
            {
                _sqlConn.Open();
                return _sqlConn.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        
        /// <summary>
        /// This method is used to execute a stored procedure that is expected to return a single scalar value 
        /// </summary>
        /// <param name="procedureName">Name of the StoredProcedure to be executed </param>
        /// <param name="param">Parameter list to be supplied to SP </param>
        /// <returns>Value returned from the execution fo Stored Procedure </returns>
        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (_sqlConn = new SqlConnection(Db.ConnectionString))
            {
                _sqlConn.Open();
                var value = _sqlConn.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }
        
        /// <inheritdoc />
        /// <summary>
        /// This is the Dispose implementation for interface
        /// </summary>
        public void Dispose()
        {
            _sqlConn.Close();
        }

        #endregion

    }
}
