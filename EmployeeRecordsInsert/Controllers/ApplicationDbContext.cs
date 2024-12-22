using EmployeeRecordsInsert.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeRecordsInsert.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<EmployeeData> EmployeeRecord { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}