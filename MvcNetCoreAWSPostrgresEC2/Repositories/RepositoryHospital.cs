using Microsoft.EntityFrameworkCore;
using MvcNetCoreAWSPostrgresEC2.Data;
using MvcNetCoreAWSPostrgresEC2.Models;

namespace MvcNetCoreAWSPostrgresEC2.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync
            (int idDepartamento)
        {
            return await this.context.Departamentos
                .FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }

        public async Task InsertDepartamentoAsync
            (int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.Departamentos.AddAsync(departamento);
            await this.context.SaveChangesAsync();
        }

    }
}
