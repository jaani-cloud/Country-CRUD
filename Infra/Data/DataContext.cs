using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Country> countries { get; set; }
}
