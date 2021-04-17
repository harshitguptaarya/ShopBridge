#region Namespace

using ShopBridge.Models;
using Microsoft.Extensions.Options;

#endregion


namespace ShopBridge.Interface
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Member

        private MySettings Db { get; set; }
      
        #endregion

        #region Constructor

        public UnitOfWork(IOptions<MySettings> options)
        {
            Db = options.Value;
            StoredProcedureCall = new StoredProcedureCall(Db);
        }

        #endregion

        #region Public Member

        public IStoredProcedureCall StoredProcedureCall { get; }

        public void Dispose()
        {
        }

        #endregion
        
    }
}
