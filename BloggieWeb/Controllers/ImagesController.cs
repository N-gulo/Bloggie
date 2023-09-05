using BloggieWeb.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BloggieWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository=imageRepository;
        }

        //get method
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            // call repo
            var imageURL = await imageRepository.UploadAsync(file);

            if (imageURL == null)
            {
                return Problem("Something went wrong" , null , (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageURL});
        }
    }
}
// https://res.cloudinary.com/dmnccuu89/image/upload/v1687510768/yvqeq1q6eg9xijykyrbe.jpg