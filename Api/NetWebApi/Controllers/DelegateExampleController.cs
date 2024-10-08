﻿using Microsoft.AspNetCore.Mvc;
using NetWebApi.Middlewares;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelegateExampleController : Controller
    {
        [HttpGet("test")]
        public IActionResult Index()
        {
            string text = new FormatTextExampleWithDelegate().Format(
                "Este es un curso de programación en EducacionIT",
                FormatTextExampleWithDelegate.FirstLetterUpperCase);

            string text2 = new FormatTextExampleWithDelegate().Format(
                "Este es un curso de programación en EducacionIT",
                FormatTextExampleWithDelegate.SecondLetterUpperCase);

            string text3 = new FormatTextExampleWithDelegate().Format(
               "Este es un curso de programación en EducacionIT",
               CustomFormat);

            return Ok(text);
        }

        [HttpGet("makeException")]
        public IActionResult MakeException()
        {
            int.Parse("a");
            return Ok();
        }

        private string CustomFormat(string text)
        {
            return text.ToUpper();
        }
    }
}
