// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAdapter.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------


namespace IndiaCensusDataDemo
{
    using System.IO;
    /// <summary>
    /// Census Adapter Class provides csv file in array form
    /// </summary>
    public class CensusAdapter
    {
        /// <summary>
        /// gives data in array form 
        /// checks if file is existing with proper type and headers
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            string[] censusData;
            ///checks if file exists otherwise exception is thrown 
            if (!File.Exists(csvFilePath))
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.Exception.FILE_NOT_FOUND);
            ///checks if file has correct file path otherwise exception is thrown 
            if (Path.GetExtension(csvFilePath) != ".csv")
                throw new CensusAnalyserException("Invalid file type", CensusAnalyserException.Exception.INVALID_FILE_TYPE);
            ///reading all lines and storing in census data (array)
            censusData = File.ReadAllLines(csvFilePath);
            ///checks if headers are correct otherwise exception is thrown 
            if (censusData[0] != dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.Exception.INCORRECT_HEADER);
            }
            return censusData;
        }
    }
}