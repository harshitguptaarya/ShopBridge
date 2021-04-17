#region NameSpace

using NLog;
using System;
using System.Globalization;
using System.Text;

#endregion

namespace ShopBridge.Utilities
{
    public class LogNLog : ILog
    {
        #region Private Member

        private ILogger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Action Method

        /// <summary>
        /// Method for saving error in file.
        /// </summary>
        /// <param name="exception">Exception exception</param>
        public void Error(Exception exception)
        {
            try
            {
                var currentDateTime = DateTime.Now;
                var currentDate = currentDateTime.ToShortDateString().Replace("/", "-");
                StringBuilder sb = new StringBuilder();
                sb.Append("\r\nLog Entry : ");
                sb.Append("-------------------------------------------------------------------------------");
                sb.AppendLine(Environment.NewLine);
                sb.Append("DateTime:\t");
                sb.Append(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                sb.AppendLine(Environment.NewLine);
                sb.Append("Error Message:\t" + exception.Message);
                sb.AppendLine(Environment.NewLine);
                sb.Append("Exception Trace:\t" + exception);
                if (exception.InnerException != null)
                {
                    sb.AppendLine(Environment.NewLine);
                    sb.AppendLine("Inner exception:\t" + exception);
                }
                sb.AppendLine(Environment.NewLine);
                sb.Append("-------------------------------------------------------------------------------");

                _logger.Error(sb.ToString());
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        #endregion

    }
}
