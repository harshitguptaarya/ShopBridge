#region Namespace

using System;

#endregion

namespace ShopBridge.Utilities
{
    /// <summary>
    /// This interface is used to provide method definitions for logging 
    /// </summary>
    public interface ILog
    {
        void Error(Exception message);

    }
}
