using Microsoft.AspNetCore.Mvc;
using WordCountCore.interfaces;

namespace Wordcount.Controllers
{
    [ApiController]
    [Route("/api")]
    public abstract class WordCountControllerBase : ControllerBase
    {
        protected ILogger Logger;

        protected WordCountControllerBase(
            ILogger logger)
        {
            Logger = logger;
        }

        public abstract Task<ActionResult<int>> CountWords(IFormFile file);
    }
}