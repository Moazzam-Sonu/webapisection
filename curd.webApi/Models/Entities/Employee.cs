﻿namespace curd.webApi.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public  string? Phone { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
    }
}
