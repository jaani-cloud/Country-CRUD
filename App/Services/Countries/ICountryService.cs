using App.DTOs;

namespace App.Services.Countries;

public interface ICountryService
{
    public string Add(CountryCreateUpdateDto input);
    public string Update(CountryCreateUpdateDto input, int id);
    public string Delete(int id);
    public List<CountryResponseDto> GetAll();
    public CountryResponseDto GetById(int id);
    public CountryResponseDto GetByName(string name);
}
 