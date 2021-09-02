using System;
using System.Collections.Generic;
using System.Text;
using IndianStateCensusAnalyser.POCO;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary>
        /// Enum for number of constants
        /// </summary>
        public enum Country
        {
            INDIA, USA , US
        }
        Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string ,CensusDTO> LoadCensusData(Country country , string csvfilePath , string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvfilePath, dataHeaders);
            return dataMap;
        }
    }
}

