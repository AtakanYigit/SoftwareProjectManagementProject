﻿using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.Allergy;
using Entity.Dtos.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _postService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpostdetails")]
        public IActionResult GetPostDetails()
        {
            var result = _postService.GetPostDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpostdetailsbyuserid")]
        public IActionResult GetPostDetailsByUserId([FromHeader] int userId)
        {
            var result = _postService.GetPostDetailsByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PostForCreateDto post)
        {
            var result = _postService.Add(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlist")]
        public IActionResult AddList(List<PostForCreateDto> posts)
        {
            var result = _postService.AddList(posts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(PostForCreateDto post)
        {
            var result = _postService.Update(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Post post)
        {
            var result = _postService.Delete(post);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _postService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("deletelist")]
        public IActionResult DeleteList(List<Post> posts)
        {
            var result = _postService.DeleteList(posts);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
