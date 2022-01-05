namespace TreinamentoBitzen.ViewModels
{
    public class DriverViewModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string CnhNumber { get; set; }
        public int CnhCategoryId { get; set; }
        public System.DateTime BirthDate { get; set; }
    }
}