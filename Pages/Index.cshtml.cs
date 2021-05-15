using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using testmvc.Models;

namespace testmvc.Pages
{
    public class IndexModel : PageModel
    {
        public List<SelectListItem> Items => 
        Enumerable.Range(1, 20).Select(x => new SelectListItem {
            Value = x.ToString(),
            Text = x.ToString()
        }).ToList();

        [BindProperty]
        [DisplayName("Age")]
        public int Age { get; set; }
        [BindProperty]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [BindProperty]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        
        public string Message { get; set; } = "Initial Request";
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("OnGet started!!");
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("OnPost started!!");
            this.Message = "OnPost started!!";
            _logger.LogInformation(Age.ToString());
            return Page();
        }

        public void OnPostView(int id)
        {
            _logger.LogInformation("OnPostView started!!");
            _logger.LogInformation(Age.ToString());
            this.Message = $"OnPostView fired for {id}";
        }
    }
}
