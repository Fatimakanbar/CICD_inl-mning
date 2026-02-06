using Microsoft.AspNetCore.Mvc;

namespace CICD_kryptering.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        private const int Shift = 3; 

        // POST: /encryption/encrypt.
        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest("Text is empty");
            
                // Krptering: flytta verje tecken shift steg fram
            var encrypted = new string (text .Select(c => (char)(c + Shift)).ToArray());
            return Ok(encrypted);
        }
    
    [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] string text)
        {
            if (string.IsNullOrEmpty(text)) // Kontrollera om input är tom
                return BadRequest("Text is empty");
            
                // Dekryptering: flytta varje tecken shift steg bakåt
            var decrypted = new string (text .Select(c => (char)(c - Shift)).ToArray());
            return Ok(decrypted);
        }
    
    
    }

}