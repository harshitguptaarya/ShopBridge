namespace ShopBridge.Utilities
{
    public static class Routes
    {
        public const string CONTROLLER_ROUTE = "api/[controller]";
        public const string ADD_ITEM = "AddItem";
        public const string EDIT_ITEM = "EditItem";
        public const string DELETE_ITEM = "DeleteItem";
        public const string GET_ITEMS = "GetItems";
    }

    public static class SQLParameters
    {
        #region hard coded sql parameters

        public const string ID = "@Id"; 
        public const string NAME = "@Name";
        public const string DESCRIPRION = "@Descriprion"; 
        public const string PRICE = "@Price";

        #endregion
    }

    public static class ProcedureNames
    {
        #region hard coded sql procedure names

        public const string SAVE_ITEM_DATA = "SaveItemData";
        public const string EDIT_ITEM_DATA = "EditItemData";
        public const string DELETE_ITEM_DATA = "DeleteItemData";
        public const string GET_ITEM_LIST = "GetItemList";

        #endregion
    }

    public static class Common
    {
        #region Common hard coded values

        public const string SUCCESS = "SUCCESS";
        public const string FAIL = "FAIL";
        public const string SUCCESS_CODE = "200";
        public const string ERROR_CODE = "500";
        public const string SESSION_ERROR_CODE = "401";
        public const string INVALID_TOKEN = "Invalid Token";
        public const string SESSION_EXPIRED = "Session expired";
        public const string INSUFFICIENT_DATA = "Insufficient data";
        public const string EMPTY_STRING = "[]";
        public const string SUCCESS_VAL = "1";
        public const string FAIL_VAL = "0";

        #endregion

    }

}