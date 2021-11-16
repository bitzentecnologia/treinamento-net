using TreinamentoBitzen.Dados.Entidades;

namespace TreinamentoBitzen.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string LicensePlate { get; set; }
        public string Name { get; set; }
        public int FuelTypesId { get; set; }
        public int ManufacturersId { get; set; }
        public int ManufactureYear { get; set; }
        public int TankCapacity { get; set; }
        public string Remarks { get; set; }

        public virtual FuelType FuelType { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}