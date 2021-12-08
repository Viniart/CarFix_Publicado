using CarFix.Project.Contexts;
using CarFix.Project.Domains;
using CarFix.Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flunt.Notifications;
using CarFix.Project.DTO;

namespace CarFix.Project.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly CarFixContext c_Context;

        public VehicleRepository(CarFixContext _context)
        {
            c_Context = _context;
        }

        public void Delete(Guid idVehicle)
        {
            Vehicle selectedVehicle = c_Context.Vehicles.Find(idVehicle);

            c_Context.Vehicles.Remove(selectedVehicle);
        }

        public Vehicle? FindVehicle(Guid idVehicle)
        {
            Vehicle? searchVehicle = c_Context.Vehicles.FirstOrDefault(x => x.Id == idVehicle);

            if(searchVehicle != null)
            {
                return searchVehicle;
            }

            return null;
        }

        public List<Vehicle> ListAllVehicles()
        {
            return c_Context.Vehicles
                .AsNoTracking()
                .Include(x => x.User)
                .ToList();
        }

        public List<Vehicle>? ListMyVehicles(Guid idUser)
        {
            List<Vehicle>? vehicles = c_Context.Vehicles
                .AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.IdUser == idUser)
                .ToList();

            if (vehicles != null)
            {
                return vehicles;
            }

            return null;
        }

        public List<Vehicle>? FindVehiclePerUser(Guid idUser)
        {
            List<Vehicle>? vehicles = c_Context.Vehicles
                .AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.IdUser == idUser)
                .ToList();

            if(vehicles != null)
            {
                return vehicles;
            }

            return null;
        }

        public void Register(Vehicle newVehicle)
        {
            c_Context.Vehicles.Add(newVehicle);
        }

        public void Update(UpdateVehicleDTO vehicle)
        {
            Vehicle searchVehicle = c_Context.Vehicles.FirstOrDefault(x => x.Id == vehicle.IdVeiculo);

            if (vehicle.LicensePlate != null)
            {
                searchVehicle.LicensePlate = vehicle.LicensePlate;
            }
            if (vehicle.ModelName != null)
            {
                searchVehicle.ModelName = vehicle.ModelName;
            }
            if (vehicle.BrandName != null)
            {
                searchVehicle.BrandName = vehicle.BrandName;
            }
            if (vehicle.Year != null)
            {
                searchVehicle.Year = (int)vehicle.Year;
            }
            if (vehicle.Color != null)
            {
                searchVehicle.Color = vehicle.Color;
            }
            if (vehicle.VehicleImage != null)
            {
                searchVehicle.VehicleImage = vehicle.VehicleImage;
            }
        }
    }
}
