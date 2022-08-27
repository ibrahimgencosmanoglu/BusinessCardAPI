using BusinessCardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCardAPI.Repository
{
    public interface IBusinessCardRepository
    {
        Task<IEnumerable<BusinessCard>> Get();
        Task<BusinessCard> Get(int id);
        Task<BusinessCard> Create(BusinessCard businessCard);
        Task Update(BusinessCard businessCard);
        Task Delete(int id);
    }
}
