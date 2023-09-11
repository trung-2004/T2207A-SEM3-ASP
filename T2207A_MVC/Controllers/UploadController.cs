using Microsoft.AspNetCore.Mvc;

namespace T2207A_MVC.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui long chon file");
            }
            string path = "wwwroot/uploads";
            string fileName = Guid.NewGuid().ToString() // chuoi string ngaau nhien
                + Path.GetExtension(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            image.CopyTo(new FileStream(upload, FileMode.Create));
            string url = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";
            return Ok(url);
        }
    }
}
