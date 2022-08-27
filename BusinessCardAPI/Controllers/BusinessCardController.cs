using BusinessCardAPI.Models;
using BusinessCardAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCardController : ControllerBase
    {
        private readonly IBusinessCardRepository _businessCardRepository;
        public BusinessCardController(IBusinessCardRepository businessCardRepository)
        {
            _businessCardRepository = businessCardRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<BusinessCard>> GetBusinessCards()
        {
            return await _businessCardRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessCard>> GetBusinessCards(int id)
        {
            return await _businessCardRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessCard>> PostBusinessCard([FromBody] BusinessCard businessCard) 
        {
            var newBusinessCard = await _businessCardRepository.Create(businessCard);
            return CreatedAtAction(nameof(GetBusinessCards), new { id = newBusinessCard.id }, newBusinessCard);
        }
        [HttpPut]
        public async Task<ActionResult> PutBusinessCard(int id, [FromBody] BusinessCard businessCard) 
        {
            if (id != businessCard.id) 
            {
                return BadRequest();
            }
            await _businessCardRepository.Update(businessCard);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var businesssCard = _businessCardRepository.Get(id);
            if (businesssCard == null) 
            {
                return NotFound();
            }
            await _businessCardRepository.Delete(businesssCard.Result.id);
            return NoContent();
        }
    }   
}
