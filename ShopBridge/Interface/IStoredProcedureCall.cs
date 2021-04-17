#region Namespace

using System;
using System.Collections.Generic;
using Dapper;

#endregion

namespace ShopBridge.Interface
{
    /// <inheritdoc />
    /// <summary>
    /// This interface provides method definition for stored procedure calls 
    /// </summary>
    public interface IStoredProcedureCall : IDisposable
    {
        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);
        
        T Single<T>(string procedureName, DynamicParameters param = null);
        
    }
}
