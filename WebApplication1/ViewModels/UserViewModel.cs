﻿namespace WebApplication1.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }
}
