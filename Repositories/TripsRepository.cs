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

        internal Trip GetById(int id)
        {
            string sql = @"
            SELECT 
            t.*,
            a.* 
            FROM trips t
            JOIN accounts a ON t.creatorId = a.id
            WHERE t.id = @id;
            ";
            return _db.Query<Trip, Account, Trip>(sql, (trip, account) =>
            {
                trip.Creator = account;
                return trip;
            }, new { id }).FirstOrDefault();
        }

        internal Trip Create(Trip tripData)
        {
            string sql = @"
            INSERT INTO trips
            (name, creatorId)
            VALUES
            (@Name, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, tripData);
            tripData.Id = id;
            return tripData;
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM trips WHERE id = @id LIMIT 1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "deleted";
            }
            throw new Exception("could not delete");
        }

        internal void Update(Trip original)
        {
            string sql = @"
            UPDATE
                trips
            SET
                name = @Name
            WHERE
                id = @Id;";
            _db.Execute(sql, original);
        }
    }
}