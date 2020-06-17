using NationalParkWeb.Models;
using NationalParkWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NationalParkWeb.Repository
{
    public class NationalParkRepository: Repository<NationalPark>, INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientfactory;
        public NationalParkRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory)
        {
            _httpClientfactory = httpClientFactory;
        }
    }
}
