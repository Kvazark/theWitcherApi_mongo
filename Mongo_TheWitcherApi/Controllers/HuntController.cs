using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mongo_TheWitcherApi.Models;
using Mongo_TheWitcherApi.Services;

namespace Mongo_TheWitcherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HuntController: ControllerBase
    {
        private readonly HuntingService _huntingService;

        public HuntController(HuntingService huntingService) =>
            _huntingService = huntingService;

        [HttpGet]
        public async Task<List<Hunt>> Get() =>
            await _huntingService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Hunt>> Get(string id)
        {
            var hunt = await _huntingService.GetAsync(id);

            if (hunt is null)
            {
                return NotFound();
            }

            return hunt;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hunt newHunt)
        {
            await _huntingService.CreateAsync(newHunt);

            return CreatedAtAction(nameof(Get), new { id = newHunt.Id }, newHunt);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Hunt updatedHunt)
        {
            var hunt = await _huntingService.GetAsync(id);

            if (hunt is null)
            {
                return NotFound();
            }

            updatedHunt.Id = hunt.Id;

            await _huntingService.UpdateAsync(id, updatedHunt);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var hunt = await _huntingService.GetAsync(id);

            if (hunt is null)
            {
                return NotFound();
            }

            await _huntingService.RemoveAsync(id);

            return NoContent();
        }
    }
}