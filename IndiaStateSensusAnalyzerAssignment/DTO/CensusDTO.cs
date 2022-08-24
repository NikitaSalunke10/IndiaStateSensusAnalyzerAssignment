
using IndiaStateSensusAnalyzerAssignment.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateSensusAnalyzerAssignment.DTO
{
    public class CensusDTO //this class is used to assign the values through constructor
    {
        public string state;
        public long population;
        public long area;
        public long density;
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
    }
}
