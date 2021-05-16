using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "First Name is required.")]
        public string firstName { get; set; }

        [BindProperty]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [BindProperty]
        [DisplayName("Address")]
        public string address { get; set; }

        [BindProperty]
        [DisplayName("City")]
        public string city { get; set; }

        [BindProperty]
        [DisplayName("State")]
        public string state { get; set; }

        [BindProperty]
        [DisplayName("Zip Code")]
        public string zipcode { get; set; }

        [BindProperty]
        [RegularExpression("^[_A-Za-z'`+-.]+([_A-Za-z0-9'+-.]+)*@([A-Za-z0-9-])+(\\.[A-Za-z0-9]+)*(\\.([A-Za-z]*){3,})$",ErrorMessage="Invalid Email Address.")]
        [DisplayName("EMail")]
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage="Invalid Email Address.")]
        public string email { get; set; }
        
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

        public void OnPostFirstSubmit()
        {
            _logger.LogInformation("FirstSubmit Triggered!!");
            this.Message = "FirstSubmit Triggered!!";
        }

        public void OnPostSecondSubmit()
        {
            _logger.LogInformation("SecondSubmit Triggered!!");
            this.Message = "SecondSubmit Triggered!!";
        }
    }
}
