using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnvisoDemo.web.DBModel
{
    public class Customer
    {
        public int Id { get; set; }
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }

        public IdentityUser IdentityUser { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public LicenseType LicenseType { get; set; }
        public DateTime CreateDate
        {
            get => _dateCreated ?? DateTime.Now;

            set { this._dateCreated = value; }
        }
        private DateTime? _dateCreated = null;
        public DateTime ExpiredDate { get; set; }
        public bool IsActive
        {
            get => _isActive;

            set { this._isActive = true; }
        }

        private bool _isActive = true;
    }
}
