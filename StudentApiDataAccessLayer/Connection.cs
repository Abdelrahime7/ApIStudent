using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApiDataAccessLayer
{
    internal static class Connection
    {

        public static string ConnectionString()
        {
            var Configuration  =  new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();

            string ? connstring = Configuration.GetSection("Constr").Value;

            if (connstring != null )
            {
                return connstring;
            }
            return "";
        }
    }
}
