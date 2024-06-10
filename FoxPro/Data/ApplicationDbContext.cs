using FoxPro.Models;
using Microsoft.EntityFrameworkCore;

namespace FoxPro.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }
}
