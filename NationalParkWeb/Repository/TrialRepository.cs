using NationalParkWeb.Models;
using NationalParkWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NationalParkWeb.Repository
{
    public class TrialRepository:Repository<Trial>, ITrialRepository
    {
        private readonly IHttpClientFactory _httpClientfactory;
        public TrialRepository(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientfactory = httpClientFactory;
        }
    }
}
