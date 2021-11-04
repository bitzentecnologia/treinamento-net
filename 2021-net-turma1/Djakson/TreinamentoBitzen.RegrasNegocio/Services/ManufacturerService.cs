using System.Collections.Generic;
using System.Linq;
using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.RegrasNegocio.Services
{
    public class ManufacturerService
    {
        public List<Manufacturer> List()
        {
            using (var context = new TreinamentoContext())
            {
                var listManufacters = context.ListManufacturers;

                return listManufacters.ToList();
            }
        }
        public Manufacturer GetById(int id)
        {
            using (var context = new TreinamentoContext())
            {
                var manufacturer = context.ListManufacturers.FirstOrDefault(x => x.Id == id);

                return manufacturer;
            }
        }
        public bool Save(Manufacturer obj)
        {
            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Added;

                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
        public bool Update(Manufacturer obj)
        {
            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Modified;

                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
        public bool DeleteById(int id)
        {
            var obj = GetById(id);

            if (obj == null)
                return true;

            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
    }
}
