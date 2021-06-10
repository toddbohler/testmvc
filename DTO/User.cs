using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

public class User {
    [Key]
    public int id {get;set;}
    public int age { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipcode { get; set; }
    public string email { get; set; }
}