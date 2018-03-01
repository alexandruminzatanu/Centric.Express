﻿using CentricExpress.Business.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace CentricExpress.Business.DTOs
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(3000)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 100000)]
        public double Price { get; set; }

        public byte[] Picture { get; set; }

        public static Item MapFromModel(ItemDto item)
        {
            return item != null ?
                new Item
                {
                    Id = item.Id,
                    Description = item.Description,
                    Price = item.Price
                } : null;
        }
    }
}
