using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.Models;
using PostService.Services;

namespace PostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // Best Practice : Using DTO object to get request 
        // Best Practice : Using Mapper like AutoMapper or Mapster

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            var result = await _postService.Add(post);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("There is an error in your inputs");
        }
    }
}
