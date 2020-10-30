using IndiaCensusDataDemo;
using IndiaCensusDataDemo.DTO;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        // Headers String
        public static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        // TC 1 : File paths
        public static string indianStateCensusFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCensusData.csv";
        public static string indianStateCodeFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.csv";

        // TC 2 : Wrong File Paths
        public static string indianStateCensusWrongFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles1\IndiaStateCensusData.csv";
        public static string indianStateCodeWrongFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles1\IndiaStateCode.csv";

        // TC 3 : Incorrect File type
        public static string wrongIndianStateCensusFileType = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";
        public static string wrongIndianStateCodeFileType = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\IndiaStateCode.txt";

        // TC 4 : Incorrect Delimeter Files' path
        public static string delimeterIndianStateCensusFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public static string delimeterIndianStateCodeFilePath = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\DelimiterIndiaStateCode.csv";

        // TC 5 : Incorrect CSV Header
        public static string wrongHeaderIndianStateCensusFile = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongIndiaStateCensusData.csv";
        public static string wrongHeaderIndianStateCodeFile = @"C:\Users\Sai\source\repos\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        /// <summary>
        /// Sets up the instances.
        /// </summary>
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC 1.1 : Given the indian state census data file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// TC 1.2 : Given the wrong file path for indian state census data file should throw custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCensusDataFile_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusWrongFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.3 : Given the wrong indian census data file type should throw custom exceotion.
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_ShouldThrowCustomExceotion()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.4 : Given the state census CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButDelimeterIncorrect_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, indianStateCensusResult.exception);
        }

        /// <summary>
        /// TC 1.5 : Givens the state census CSV file when correct but CSV header incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCensusCSVFileWhenCorrectButCSVHeaderIncorrect_ShouldThrowCustomException()
        {
            var indianStateCensusResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongHeaderIndianStateCensusFile, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianStateCensusResult.exception);
        }
        /// <summary>
        /// Given State Code File Should Return Census Count
        /// Uc2-Tc1
        /// </summary>
        [Test]
        public void GivenStateCodeFile_ShouldReturnCensusCount()
        {
            ///Act
           var stateRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            ///Assert
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// Given Wrong StateCode File Should Return CustomException
        /// Uc2-Tc2
        /// </summary>
        [Test]
        public void GivenWrongStateCodeFile_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeWrongFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, stateResult.exception);
        }

        /// <summary>
        /// Given Wrong State CodeFile Type Should Return CustomException
        /// Uc2-Tc3
        /// </summary>
        [Test]
        public void GivenWrongStateCodeFileType_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, stateResult.exception);
        }

        /// <summary>
        /// Given StateCode Delimeter FileType Should Return CustomException
        /// Uc2-Tc4
        /// </summary>
        [Test]
        public void GivenStateCodeDelimeterFileType_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, stateResult.exception);
        }

        /// <summary>
        /// Given Wrong StateCode Header Should Return CustomException
        /// Uc2-Tc5
        /// </summary>
        [Test]
        public void GivenWrongStateCodeHeader_ShouldReturnCustomException()
        {
            ///Act
            var stateResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimeterIndianStateCodeFilePath, indianStateCodeHeaders));
            ///Assert
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_DELIMITER, stateResult.exception);
        }

    }
}
