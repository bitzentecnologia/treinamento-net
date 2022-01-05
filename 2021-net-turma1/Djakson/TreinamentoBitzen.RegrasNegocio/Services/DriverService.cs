using System.Collections.Generic;
using System.Linq;
using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.RegrasNegocio.Services
{
    public class DriverService
    {
        public List<Driver> List()
        {
            using (var context = new TreinamentoContext())
            {
                var listDrivers = context.ListDrivers;

                return listDrivers.ToList();
            }
        }
        public Driver GetById(int id)
        {
            using (var context = new TreinamentoContext())
            {
                var Driver = context.ListDrivers.FirstOrDefault(x => x.Id == id);

                return Driver;
            }
        }
        public bool Save(Driver obj)
        {
            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Added;

                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
        public bool Update(Driver obj)
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
