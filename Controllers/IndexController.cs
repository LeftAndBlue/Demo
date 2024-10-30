using IService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebReadSite.Models;
using WebReadSite.utils;

namespace WebReadSite.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    [ApiController]
    [Route("[controller]/[Action]")]
    [EnableCors("AllowSpecificOrigin")]
    public class IndexController: ControllerBase
    {
        private readonly IBookService _bookService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bookService"></param>
        public IndexController(IBookService bookService)
        {
            _bookService=bookService;
        }

        /// <summary>
        /// 轮播图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IndexBanner()
        {
            MemoryStream stream;
            using (FileStream fs = new FileStream("resource/sheep.png", FileMode.Open))
            {
                int len = (int)fs.Length; 
                byte[] buf = new byte[len];
                //文件流读入图像数据
                fs.Read(buf, 0, len);
                //创建内存流对象
                stream = new MemoryStream();
                //图像数据由文件流写入内存流                                         
                stream.Write(buf, 0, len);
            }
            return await Task.FromResult<FileResult>(File(stream.ToArray(), "image/gif"));
        }
        //public async Task<IActionResult>BookBanner(string bookBannerUrl)
        //{
        //    return
        //}
        /// <summary>
        /// 首页推荐书籍
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult IndexRecommend()
        {

            return new JsonResult(new ApiDataResult<List<Book>>()
            {
                Success = true,
                Data = _bookService.GetAllBook()?.Take(10).ToList(),
                Message="图书列表"
            }) ; 
        }
    }
}
