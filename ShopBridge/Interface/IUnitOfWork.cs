#region Namespace

using System;

#endregion


namespace ShopBridge.Interface
{
    public interface IUnitOfWork : IDisposable
    {
       
        IStoredProcedureCall StoredProcedureCall { get; }

    }
}
