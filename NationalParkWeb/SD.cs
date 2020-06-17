using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkWeb
{
    public static class SD
    {
        public static string APIBaseUrl = "https://localhost:44390/";
        public static string NationalParkAPIPath = APIBaseUrl + "api/nationalpark";
        public static string TrialAPIPath = APIBaseUrl + "api/trails";
    }
}
