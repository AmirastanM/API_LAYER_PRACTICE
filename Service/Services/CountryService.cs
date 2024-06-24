using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepo,
                                IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;   
        }
        public async Task CreateAsync(CountryCreateDto model)
        {
            if(model is null) throw new ArgumentNullException();
            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));

        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            if (model is null) throw new ArgumentNullException();
            var existingCountry = await _countryRepo.GetById(id);
            if (existingCountry == null) throw new KeyNotFoundException("Country not found");

            existingCountry.Name = model.Name; // Обно

            await _countryRepo.EditAsync(existingCountry);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }
    }
}
