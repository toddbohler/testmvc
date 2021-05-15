using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace testmvc.Models
{
    public class Person : IPerson
    {
        [BindProperty]
        [DisplayName("Age")]
        public int Age { get; set; }

        [BindProperty]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [BindProperty]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
    }
}
