using System;
using System.Collections.Generic;
using PlanesTrainsandAutomobiles.Models;
using PlanesTrainsandAutomobiles.Repositories;

namespace PlanesTrainsandAutomobiles.Services
{
    public class TripsService
    {
        private readonly TripsRepository _tRepo;

        public TripsService(TripsRepository tRepo)
        {
            _tRepo = tRepo;
        }

        internal List<Trip> GetAll()
        {
            return _tRepo.GetAll();
        }
    }
}