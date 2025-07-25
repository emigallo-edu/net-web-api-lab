﻿using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class Club
    {
        public Club()
        {
            this.Players = new List<Player>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        public string Email { get; set; }

        [Range(1, 9999)]
        public int NumberOfPartners { get; set; }

        public string Phone { get; set; }

        public string? Address { get; set; }

        public string? StadiumName { get; set; }

        public ICollection<Player> Players;

        public Stadium? Stadium { get; set; }

        public bool IsFromBuenosAires()
        {
            return this.City == "BsAs";
        }

        public Club GetDTO()
        {
            return new Club()
            {
                Id = this.Id,
                Name = this.Name,
                Birthday = this.Birthday,
                City = this.City,
                Email = this.Email,
                NumberOfPartners = this.NumberOfPartners,
                Phone = this.Phone,
                Address = this.Address,
                StadiumName = this.StadiumName,
                Players = this.Players,
                Stadium = null
            };
        }
    }
}