using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Logging.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string Message { get; set; }
        public string PageTitle => _configuration["PageTitle"];

        public void OnGet()
        {
            Message = $"About page visited at {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);
            _logger.LogCritical("this is critical");
      ;
        }
    }
}
