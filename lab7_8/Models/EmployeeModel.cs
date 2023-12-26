﻿namespace lab7_8.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string Country { get; set; }
        public bool IsEmployed { get; set; }
        public decimal Salary { get; set; }
    }
}