using App.DTOs;
using App.Services.Countries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/country")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("add")]
    public void Add(CountryCreateUpdateDto input)
    {
        _countryService.Add(input);
    }

    [HttpPut("update/{id}")]
    public void Update(CountryCreateUpdateDto input, int id)
    {
        _countryService.Update(input, id);
    }

    [HttpDelete("delete/{id}")]
    public void Delete(int id)
    {
        _countryService.Delete(id);
    }

    [HttpGet("get-all")]
    public List<CountryResponseDto> GetAll()
    {
        return _countryService.GetAll();
    }

    [HttpGet("get-by-id/{id}")]
    public CountryResponseDto Get(int id) {
        return _countryService.GetById(id);
    }

    [HttpGet("get-by-name/{name}")]
    public CountryResponseDto Get(string name) {
        return _countryService.GetByName(name);
    }
}
