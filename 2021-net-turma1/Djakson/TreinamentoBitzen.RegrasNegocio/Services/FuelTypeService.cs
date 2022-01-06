using System.Collections.Generic;
using System.Linq;
using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.RegrasNegocio.Services
{
    public class FuelTypeService
    {
        public List<FuelType> List()
        {
            using (var context = new TreinamentoContext())
            {
                var listFuelTypes = context.ListFuelTypes;

                return listFuelTypes.ToList();
            }
        }
        public FuelType GetById(int id)
        {
            using (var context = new TreinamentoContext())
            {
                var FuelType = context.ListFuelTypes.FirstOrDefault(x => x.Id == id);

                return FuelType;
            }
        }
        public bool Save(FuelType obj)
        {
            using (var context = new TreinamentoContext())
            {
                context.Entry(obj).State = System.Data.Entity.EntityState.Added;

                var rowsAffected = context.SaveChanges();
                return rowsAffected > 0;
            }
        }
        public bool Update(FuelType obj)
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
