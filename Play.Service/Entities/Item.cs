﻿using System;
namespace Play.Service.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Descriprion { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
     } 
}