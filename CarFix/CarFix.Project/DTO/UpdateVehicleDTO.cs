using System;

namespace CarFix.Project.DTO
{
    public class UpdateVehicleDTO
    {
        public Guid IdVeiculo { get; set; }
        public string? LicensePlate { get; set; }
        public string? ModelName { get; set; }
        public string? BrandName { get; set; }
        public int? Year { get; set; }
        public string? Color { get; set; }
        public string? VehicleImage { get; set; }
    }
}
