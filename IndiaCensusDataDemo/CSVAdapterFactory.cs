// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVAdapterFactory.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------


namespace IndiaCensusDataDemo
{
    using IndiaCensusDataDemo.DTO;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Csv Adapter Factory class
    /// </summary>
    public class CSVAdapterFactory
    {
        /// <summary>
        /// Load different csv file according to different countries
        /// </summary>
        /// <param name="country"></param>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.Exception.NO_SUCH_COUNTRY);

            }
        }
    }
}