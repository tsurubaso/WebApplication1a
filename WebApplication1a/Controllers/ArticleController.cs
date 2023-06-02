﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1a.Models;

namespace WebApplication1a.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ArticleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("AddArticle")]
        public Response AddArticle(Article article)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.AddArticle(article, connection);
            return response;

        }
        [HttpPost]
        [Route("ArticleList")]
        public Response ArticleList(Article article)


        {

            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleList(article,connection);
            return response;

        }

        [HttpPost]
        [Route("ArticleApproval")]
        public Response ArticleApproval(Article article)


        {

            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            Dal dal = new Dal();
            response = dal.ArticleApproval(article, connection);
            return response;

        }











    }
}
