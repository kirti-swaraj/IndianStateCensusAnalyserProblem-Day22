// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CensusAnalyserException.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------

namespace IndiaCensusDataDemo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Census Analyser Exception class
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        public Exception exception;

        /// <summary>
        /// enum class for different exceptions
        /// </summary>
        public enum Exception
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_HEADER,
            NO_SUCH_COUNTRY,INCORRECT_DELIMITER
        }

        /// <summary>
        ///parameterised constructor
        ///base message is passed to overide the message 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public CensusAnalyserException(string message, Exception exception) : base(message)
        {
            this.exception = exception;
        }
    }
}