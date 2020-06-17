using Microsoft.EntityFrameworkCore;
using RestApiDemo.Data;
using RestApiDemo.Modals;
using RestApiDemo.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Repository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TrailRepository : ITrialRepository
    {
        private readonly ApplicationDbContext _db;
        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateTrial(Trial trial)
        {
            _db.Add(trial);
            return Save();
        }

        public bool DeleteTrial(Trial trial)
        {
            _db.trial.Remove(trial);
            return Save();
        }

        public Trial GetTrial(int trialId)
        {
            return _db.trial.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trialId);
        }

        public ICollection<Trial> GetTrials()
        {
            return _db.trial.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();
        }

        public bool TrialExist(string name)
        {
            bool value = _db.trial.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrialExist(int id)
        {
            return _db.trial.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrial(Trial trial)
        {
            _db.trial.Update(trial);
            return Save();
        }

        public ICollection<Trial> GetTrailsInNationalPark(int npId)
        {
            return _db.trial.Include(c => c.NationalPark).Where(c => c.NationalParkId == npId).ToList();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
