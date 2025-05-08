using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostrgresEC2.Models;

namespace MvcNetCoreAWSPostrgresEC2.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) 
            : base(options){ }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
