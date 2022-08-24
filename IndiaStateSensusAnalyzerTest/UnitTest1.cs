using IndiaStateSensusAnalyzerAssignment;
using IndiaStateSensusAnalyzerAssignment.DTO;
using static IndiaStateSensusAnalyzerAssignment.CensusAnalyser;

namespace IndiaStateSensusAnalyzerTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateCensusAnalyzer\CensualAnalyzerTest\CsvFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\LENOVO\source\repos\IndianStateCensusAnalyzer\CensualAnalyzerTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string invalidFilePath = @"C:\Users\LENOVO\source\repos\IndiaStateSensusAnalyzerAssignment\IndiaStateSensusAnalyzerTest\CSV\InvalidCSVFile.txt";
        static string wrongdelimeterFilePath = @"C:\Users\LENOVO\source\repos\IndiaStateSensusAnalyzerAssignment\IndiaStateSensusAnalyzerTest\CSV\DelimiterIndiaStateCensusData.csv";
        static string wrongFilePath = @"C:\Users\LENOVO\source\repos\IndianStateCensusAnalyzer\CensualAnalyzerTest\CsvFiles\IndiaStateCensusData1.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord; 

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount() // this test case is to check whether total records matches with expected records
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()//this test case is used to check if headers are incorrect then exception is thrown or not 
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()//this test case is used to check if invalid file type is given then exception is thrown or not 
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(invalidFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenWrongDelimeterFile_WhenRead_ShouldReturnCustomException()//this test case is used to check if file contains incorrect delimiter then exception is thrown or not 
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongdelimeterFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenIncorrectFile_WhenRead_ShouldReturnCustomException()//this test case is used to check if wrong file path is given then exception is thrown or not 
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
    }
}