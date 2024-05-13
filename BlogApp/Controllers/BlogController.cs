using BlogApp.Context;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;




namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller

    {
        private readonly AppDbContext _blogContext;

        

        public BlogController(AppDbContext appDbContext)
        {
            _blogContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            return Ok(_blogContext.Blogs.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetById([FromRoute] int id) 
        {
            var blog = _blogContext.Blogs.FirstOrDefault(x=>x.BlogId==id);
            
            if (blog == null)
            {
                return NotFound();  
            }
            return Ok(blog);
        
        }


       /* [HttpGet]
        [Route("{Email}")]

        public IActionResult GetBlogs([FromRoute] string email, [FromBody] Blog Email)
        {
            var blog = _blogContext.Blogs.ToArray(x=)
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);

        }*/



        [HttpPost("Blogwrite")]
        public async Task<IActionResult> BlogPost([FromBody] Blog blogObj)
        {
            if (blogObj == null)
                return BadRequest();
            await _blogContext.Blogs.AddAsync(blogObj);
            await _blogContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Blog Created!"
            });

        }
        [HttpPut]
        [Route("{id:int}")]
        
        public IActionResult Update([FromBody] Blog blogUpdate, [FromRoute] int id)
{
    var updateBlog = _blogContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blogUpdate == null)
            {
                return NotFound();
            }
            updateBlog.Title = blogUpdate.Title;
            updateBlog.Description = blogUpdate.Description;
            updateBlog.Link = blogUpdate.Link;

    _blogContext.SaveChanges();

            return Ok(updateBlog);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var blog = _blogContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            _blogContext.Blogs.Remove(blog);
            _blogContext.SaveChanges();
            return Ok();

        }



    }
}

