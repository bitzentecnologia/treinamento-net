using System.Collections.Generic;
using System.Linq;
using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.RegrasNegocio.Services
{
    public class VehicleService
    {
        public List<Vehicle> List()
        {
            using (var context = new TreinamentoContext())
            {
                var listVehicles = context.ListVehicles;

                return listVehicles.ToList();
            }
        }
        public Vehicle GetById(int id)
        {
            using (var context = new TreinamentoContext())
            {
                var vehicle = context.ListVehicles.FirstOrDefault(x => x.Id == id);

                return vehicle;
            }
        }
        public bool Save(Vehicle obj)
        {
            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Added;

                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
        public bool Update(Vehicle obj)
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
