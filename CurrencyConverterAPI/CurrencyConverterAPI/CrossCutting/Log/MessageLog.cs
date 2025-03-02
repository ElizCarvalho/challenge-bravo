namespace CurrencyConverterAPI.CrossCutting.Log
{
    public static class MessageLog
    {
        public static string Info(string className, string methodName, string[]? param = null, string? message = null)
        {
            if (param != null)
                return String.Format("[{0}] Call method '{1}' with params: {2} - Message: {3}", className, methodName, string.Join(", ", param), message);
            else
                return String.Format("[{0}] Call method '{1}' - Message: {2}", className, methodName, message);
        }

        public static string Error(string className, string methodName, string message, string[]? param = null)
        {
            if (param != null)
                return String.Format("[{0}] Call method '{1}' generated an error message: {2} with params: {3}", className, methodName, message, string.Join(", ", param));
            else
                return String.Format("[{0}] Call method '{1}' generated an error message: {2}", className, methodName, message);
        }
    }
}