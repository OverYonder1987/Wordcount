using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WordCountCore.interfaces;

namespace Wordcount.Controllers;

[ApiController]
public class TextDocumentController : WordCountControllerBase
{
    protected readonly IWordCounter _wordCounter;

    public TextDocumentController(
        ILogger<TextDocumentController> logger,
        IWordCounter wordCounter) : base(logger)
    {
        _wordCounter = wordCounter;
    }

    [HttpPost("/api/wordcount")]
    public override async Task<ActionResult<string>> CountWords(IFormFile? file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Please select a file to upload");
            }

            if (file.FileName.Split('.').Last() != "txt")
            {
                return BadRequest("The service only supports .txt files at this moment.\nPlease select a file to upload");
            }

            using var memoryStream = new MemoryStream();
            
            await file.CopyToAsync(memoryStream);
                
            var fileBytes = memoryStream.ToArray();

            var textContent = System.Text.Encoding.UTF8.GetString(fileBytes);

            var wordCount = _wordCounter.CountWords(textContent);

            var wordCountAsJson = JsonSerializer.Serialize(wordCount);

            return Ok(wordCountAsJson);

        }
        catch (Exception e)
        {
            Logger.LogError(e, $"Error in {nameof(TextDocumentController)}");

            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
        }
    }
}
