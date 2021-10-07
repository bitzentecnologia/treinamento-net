using System.Collections.Generic;
using System.Linq;
using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.RegrasNegocio.Services
{
    public class ManufacturerService
    {
        public List<Manufacturer> List()
        {
            var context = new TreinamentoContext();
            var listManufacters = context.ListManufacturers;

            return listManufacters.ToList();
        }
        public Manufacturer GetById(int id)
        {
            var context = new TreinamentoContext();
            var manufacturer = context.ListManufacturers.FirstOrDefault(x => x.Id == id);

            return manufacturer;
        }
        public bool Save(Manufacturer obj)
        {
            var context = new TreinamentoContext();
            context.Entry(obj).State = System.Data.Entity.EntityState.Added;

            var rowsAffected = context.SaveChanges();
            return rowsAffected > 0;
        }
        public bool Update(Manufacturer obj)
        {
            var context = new TreinamentoContext();
            context.Entry(obj).State = System.Data.Entity.EntityState.Modified;

            var rowsAffected = context.SaveChanges();
            return rowsAffected > 0;
        }
        public bool DeleteById(int id)
        {
            var entity = GetById(id);

            if (entity == null)
                return true;

            var context = new TreinamentoContext();
            context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;

            var rowsAffected = context.SaveChanges();
            return rowsAffected > 0;
        }
    }
}
