using RestApiDemo.Modals;
using System.Collections.Generic;

namespace RestApiDemo.Repository.IRepository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface ITrialRepository
    {
        ICollection<Trial> GetTrials();
        ICollection<Trial> GetTrailsInNationalPark(int npId);
        Trial GetTrial(int trialId);
        bool TrialExist(string name);
        bool TrialExist(int id);
        bool CreateTrial(Trial trial);
        bool UpdateTrial(Trial trial);
        bool DeleteTrial(Trial trial);
        bool Save();
        
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
