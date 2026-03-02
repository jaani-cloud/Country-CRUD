using App.DTOs;
using Infra.Repos.Countries;
using Domain.Entities;

namespace App.Services.Countries;

public class CountryService : ICountryService
{
    private readonly ICountryRepo _countryRepo;

    public CountryService(ICountryRepo countryRepo)
    {
        _countryRepo = countryRepo;
    }

    public string Add(CountryCreateUpdateDto input)
    {
        var country = new Country
        {
            Name = input.Name
        };

         _countryRepo.Add(country);

        return $"Country {input.Name} added successfully.";
    }

    public string Delete(int id)
    {
        _countryRepo.Delete(id);
        return $"Country with id {id} deleted successfully.";
    }
    
    public List<CountryResponseDto> GetAll()
    {
        return _countryRepo.GetAll().Select(c => new CountryResponseDto
        {
            Id = c.Id,
            Name = c.Name
        }).ToList();
    }

    public CountryResponseDto GetById(int id)
    {
        var country = _countryRepo.GetById(id);
        if (country == null)
        {
            return new CountryResponseDto { Id = 0, Name = "Country not found" };
        }

        return new CountryResponseDto
        {
            Id = country.Id,
            Name = country.Name
        };
    }

    public CountryResponseDto GetByName(string name)
    {
        var country = _countryRepo.GetByName(name);
        if (country == null)
        {
            return new CountryResponseDto { Id = 0, Name = "Country not found" };
        }

        return new CountryResponseDto
        {
            Id = country.Id,
            Name = country.Name
        };
    }

    public string Update(CountryCreateUpdateDto input, int id)
    {
        var country = _countryRepo.GetById(id);
        if (country == null)
        {
            return $"Country with id {id} not found.";
        }

        country.Name = input.Name;
        _countryRepo.Update(country,id);
        return $"Country with id {id} updated successfully.";
    }
}
