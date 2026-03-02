using Domain.Entities;
using Infra.Data;

namespace Infra.Repos.Countries;

public class CountryRepo : ICountryRepo
{
    private readonly DataContext _context;

    public CountryRepo(DataContext context)
    {
        _context = context;
    }

    public string Add(Country country)
    {
        _context.countries.Add(country);
        _context.SaveChanges();
        return "Country added successfully.";
    }

    public string Delete(int id)
    {
        var country = _context.countries.Find(id);
        if (country == null)
        {
            return "Country not found.";
        }
        _context.countries.Remove(country);
        _context.SaveChanges();
        return "Country deleted successfully.";
    }

    public List<Country> GetAll()
    {
        return _context.countries.ToList();
    }

    public Country GetById(int id)
    {
        var country = _context.countries.Find(id);
        if (country == null)
        {
            return null;
        }
        return country;

    }

    public Country GetByName(string name)
    {
        var country = _context.countries.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        if (country == null)
        {
            return null;
        }
        return country;
    }

    public string Update(Country country)
    {
        _context.countries.Update(country);
        _context.SaveChanges();

        return "Country updated successfully.";
    }
}
