using Microsoft.AspNetCore.Mvc;
using Play.Service.Dots;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Play.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private static readonly List<ItemDto> Items = new()
        {
            new ItemDto(Guid.NewGuid(), "Sword", "This sword can save you", 23, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Ball", "Very fanny game is play in ball", 34, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "MacBook", "Don't need any description", 1000, DateTimeOffset.UtcNow)

        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return Items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item = Items.Where(item => item.Id == id).SingleOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price, DateTimeOffset.UtcNow);
            Items.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = Items.Where(item => item.Id == id).SingleOrDefault();

            if (existingItem == null)
            {
                return NotFound();
            }

            var updatedItem = existingItem with
            {
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };

            var index = Items.FindIndex(existingItem => existingItem.Id == id);
            Items[index] = updatedItem;
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var index = Items.FindIndex(item => item.Id == id);

            if (index < 0)
            {
                return NotFound();
            }

            Items.RemoveAt(index);

            return NoContent();

        }
    }
    
}
