using IndiaStateSensusAnalyzerAssignment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndiaStateSensusAnalyzerAssignment
{
    class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1)) //foreach loop is used to retrived records one by one and also skips the first records which are headers
            {
                if (!data.Contains(",")) // this if is used to check where the data inside file contains comma delimeter or not and if not then exception is thrown
                {
                    throw new CensusAnalyserException("File contains wrong delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(","); // the data from file is split where comma is found and store in array
                if (csvFilePath.Contains("IndiaStateCensusData.csv")) // if this condition becomes true then the records are added in dictionary
                    dataMap.Add(column[0], new CensusDTO(new POCO.CensusDataDAO(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCode.csv"))// if this condition becomes true then the records are added in dictionary
                    dataMap.Add(column[1], new CensusDTO(new POCO.StateCodeDAO(column[0], column[1], column[2], column[3])));
            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
