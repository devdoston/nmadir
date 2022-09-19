using Microsoft.EntityFrameworkCore;

namespace AjratProject.Data;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
public DbSet<PostNinViewModel>? PostNins { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options){ }
}