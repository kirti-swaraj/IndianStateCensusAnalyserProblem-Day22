// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndianCensusAdapter.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------

namespace IndiaCensusDataDemo
{
    using IndiaCensusDataDemo.DataDAO;
    using IndiaCensusDataDemo.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Indian Census Adapter Class
    /// </summary>
    public class IndianCensusAdapter : CensusAdapter
    {
        /// <summary>
        /// adds data into the data map with name as the key of the dictionary 
        /// </summary>
        string[] censusData;
        Dictionary<string, CensusDTO> datamap;
        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            /// census data will have data stored in array form used function get census data to extract data
            /// finally it is added to datamap with name(column 1) as key
            datamap = new Dictionary<string, CensusDTO>();
            censusData = GetCensusData(csvFilePath, dataHeaders);
            /// skiping the headers from loop
            foreach (string data in censusData.Skip(1))
            {
                ///if it contains any other delimeter apart from , it will throw exception
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Containers Wrong Delimiter", CensusAnalyserException.Exception.INCORRECT_DELIMITER);
                }
                ///spliting data which is splitted by commma is stored in array coloumn
                string[] coloumn = data.Split(",");
                ///checking if it is indian state code or indian census data by csv extension
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new StateCodeDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    datamap.Add(coloumn[1], new CensusDTO(new CensusDataDAO(coloumn[0], coloumn[1], coloumn[2], coloumn[3])));
            }
            return datamap.ToDictionary(p => p.Key, p => p.Value);
        }

    }
}