using RestApiDemo.Modals;
using System.Collections.Generic;

namespace RestApiDemo.Repository.IRepository
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int nationalParkId);
        bool NationalParkExist(string name);
        bool NationalParkExist(int id);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
        bool Save();
        
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
