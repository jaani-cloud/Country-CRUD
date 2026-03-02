using Domain.Entities;

namespace Infra.Repos.Countries;

public interface ICountryRepo
{
    public List<Country> GetAll();
    public Country GetById(int id);
    public Country GetByName(string name);
    public string Add(Country country);
    public string Update(Country country);
    public string Delete(int id);
}
