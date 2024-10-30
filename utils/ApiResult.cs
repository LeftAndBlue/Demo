namespace WebReadSite.utils
{
    /// <summary>
    /// Api统一返回结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 是否正常返回
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message {  get; set; }

    }
    /// <summary>
    /// Api返回数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiDataResult<T>:ApiResult
    {
        /// <summary>
        /// 结果集
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// 冗余结果
        /// </summary>
        public object? Value {  get; set; }

    }
}
