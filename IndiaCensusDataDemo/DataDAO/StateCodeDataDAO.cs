
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateCodeDataDAO.cs" company="Capgemini">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kirti Swaraj"/>
//---------------------------------------------------------------------------------------------------------------------

namespace IndiaCensusDataDemo.DataDAO
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// State code Data 
    /// </summary>
    public class StateCodeDataDAO
    {
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        public StateCodeDataDAO(string serialNumber, string stateName, string tin, string stateCode)
        {
            this.serialNumber = Convert.ToInt32(serialNumber);
            this.stateName = stateName;
            this.tin = Convert.ToInt32(tin);
            this.stateCode = stateCode;
        }
    }
}