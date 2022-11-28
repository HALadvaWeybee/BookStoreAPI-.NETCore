﻿using System.ComponentModel.DataAnnotations;
namespace BookStoreAPI.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Add title Proper")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
