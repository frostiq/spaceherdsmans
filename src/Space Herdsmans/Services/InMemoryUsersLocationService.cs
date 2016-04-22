using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Space_Herdsmans.Models;

namespace Space_Herdsmans.Services
{
    public class InMemoryUsersLocationService : IUsersLocationService
    {
        private readonly IDictionary<Guid, GeoCoordinates> _data = new ConcurrentDictionary<Guid, GeoCoordinates>();
 
        public ICollection<GeoCoordinates> GetCloseUsers(GeoCoordinates point, double radius)
        {
            return _data.Values;
        }

        public GeoCoordinates GetLastUserPosition(Guid userId) => _data[userId];


        public void UpdateUserPosition(Guid userId, GeoCoordinates point)
        {
            _data[userId] = point;
        }
    }
}
