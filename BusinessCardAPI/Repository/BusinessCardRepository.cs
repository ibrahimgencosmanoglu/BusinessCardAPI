using BusinessCardAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardAPI.Repository
{
    public class BusinessCardRepository : IBusinessCardRepository
    {
        private readonly BusinessCardContext _context;

        public BusinessCardRepository(BusinessCardContext context) 
        {
            _context = context;
        }
        public async Task<BusinessCard> Create(BusinessCard businessCard)
        {
            _context.businessCards.Add(businessCard);
            await _context.SaveChangesAsync();
            return businessCard;
        }

        public async Task Delete(int id)
        {
            var businessCardToRemove = await _context.businessCards.FindAsync(id);
            _context.Remove(businessCardToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BusinessCard>> Get()
        {
            return await _context.businessCards.ToListAsync();
        }

        public async Task<BusinessCard> Get(int id)
        {
            return await _context.businessCards.FindAsync(id);
            
        }

        public async Task Update(BusinessCard businessCard)
        {
            _context.Entry(businessCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
