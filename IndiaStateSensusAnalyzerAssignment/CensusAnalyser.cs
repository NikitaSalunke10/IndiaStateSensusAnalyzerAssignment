using IndiaStateSensusAnalyzerAssignment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateSensusAnalyzerAssignment
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA, US
        }

        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, Country country, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders); //the data retrieved from csv file is stored in datamap dictionary
            return dataMap;
        }

    }
}
