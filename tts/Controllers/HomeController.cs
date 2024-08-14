using Microsoft.AspNetCore.Mvc;
using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;
using tts.Models;

namespace tts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> ConvertToSpeech([FromBody] SpeechModel model)
        {
            try
            {
                var subscriptionKey = _configuration["AzureSpeech:SubscriptionKey"];
                var region = _configuration["AzureSpeech:Region"];

                var config = SpeechConfig.FromSubscription(subscriptionKey, region);
                config.SpeechSynthesisVoiceName = "en-US-JennyNeural"; 

                using var synthesizer = new SpeechSynthesizer(config);
                var result = await synthesizer.SpeakTextAsync(model.Text);

                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    return File(result.AudioData, "audio/wav");
                }
                else
                {
                    _logger.LogError($"Speech synthesis failed: {result.Reason}");
                    return BadRequest($"Speech synthesis failed: {result.Reason}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting text to speech");
                return BadRequest("Error converting text to speech");
            }
        }
    }
}