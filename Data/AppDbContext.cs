using Microsoft.EntityFrameworkCore;
using FrontLearn_1.Models;

namespace FrontLearn_1.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}

