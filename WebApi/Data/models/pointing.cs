using System;
using WebApi.Data.Models;

namespace WebApi.Data.models
{
    public partial class pointing
    {
        public int id { get; set; }

        public int id_account { get; set; }

        public DateTime data { get; set; }

        public TimeSpan primeiro_apontamento { get; set; }

        public TimeSpan segundo_apontamento { get; set; }

        public TimeSpan terceiro_apontamento { get; set; }

        public TimeSpan quarto_apontamento { get; set; }

        public account account { get; set; }
    }
}