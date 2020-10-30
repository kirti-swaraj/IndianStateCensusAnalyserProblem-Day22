// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAnalyser.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------

namespace IndiaCensusDataDemo
{
    using IndiaCensusDataDemo.DTO;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// census Analyser helps to load csv data 
    /// </summary>
    public class CensusAnalyser
    {
        /// <summary>
        /// creater enum for different countries 
        /// </summary>
        public enum Country
        {
            INDIA, US
        }
        /// <summary>
        /// creating a datamap to store data from csv file in the form of a dictionary 
        /// </summary>
        public Dictionary<string, CensusDTO> datamap;

        /// <summary>
        /// Extracts data from csv file 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            ///calling factory adapter by creating a direct instance of class and calling func loadcsvdata 
            ///loadcsv calls function based on different countries like can be india , usa etc
            datamap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return datamap;
        }
    }
}