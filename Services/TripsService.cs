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

        internal Trip GetById(int id)
        {
            Trip found = _tRepo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Trip Create(Trip tripData)
        {
            return _tRepo.Create(tripData);
        }

        internal string Remove(int id, Account user)
        {
            Trip game = _tRepo.GetById(id);
            if (game.creatorId != user.Id)
            {
                throw new Exception("you can't do that, nice try.");
            }
            return _tRepo.Remove(id);
        }

        internal Trip Update(Trip tripData)
        {
            Trip original = GetById(tripData.Id);
            original.Name = tripData.Name ?? original.Name;
            _tRepo.Update(original);
            return original;
        }
    }
}