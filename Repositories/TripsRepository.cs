using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using PlanesTrainsandAutomobiles.Models;


namespace PlanesTrainsandAutomobiles.Repositories
{
    public class TripsRepository
    {
        private readonly IDbConnection _db;

        public TripsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Trip> GetAll()
        {
            string sql = @"
            SELECT
            t.*,
            a.*
            FROM trips t
            JOIN accounts a WHERE a.id = t.creatorId;
            ";
            return _db.Query<Trip, Account, Trip>(sql, (trip, account) =>
            {
                trip.Creator = account;
                return trip;
            }).ToList();
        }
    }
}